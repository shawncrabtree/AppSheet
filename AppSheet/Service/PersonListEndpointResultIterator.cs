using AppSheet.Endpoint;
using AppSheet.Models;
using System.Collections;
using System.Collections.Generic;

namespace AppSheet.Service
{
    public class PersonListEndpointResultIterator : IEnumerator<PersonListResultModel>
    {
        public PersonListResultModel Current { get; private set; }
        object IEnumerator.Current => this.Current;

        private IPeopleEndpoint _peopleEndpoint;

        public PersonListEndpointResultIterator(IPeopleEndpoint peopleEndpoint)
        {
            _peopleEndpoint = peopleEndpoint;
        }

        public bool MoveNext()
        {
            if (this.Current != null && string.IsNullOrEmpty(this.Current.Token))
                return false;
            this.Current = _peopleEndpoint.GetList(this.Current?.Token).Result;
            return true;
        }

        public void Reset()
        {
            this.Current = null;
        }

        public void Dispose() { }
    }
}
