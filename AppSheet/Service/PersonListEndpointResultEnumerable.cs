using AppSheet.Endpoint;
using AppSheet.Models;
using System.Collections;
using System.Collections.Generic;

namespace AppSheet.Service
{
    public class PersonListEndpointResultEnumerable : IEnumerable<PersonListResultModel>
    {
        private PersonListEndpointResultIterator _iterator;

        public PersonListEndpointResultEnumerable(IPeopleEndpoint peopleEndpoint)
        {
            _iterator = new PersonListEndpointResultIterator(peopleEndpoint);
        }

        public IEnumerator<PersonListResultModel> GetEnumerator()
        {
            return _iterator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _iterator;
        }
    }
}
