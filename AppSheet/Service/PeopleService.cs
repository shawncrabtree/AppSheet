using AppSheet.Endpoint;
using AppSheet.Models;
using PhoneNumbers;
using System.Collections.Generic;
using System.Linq;

namespace AppSheet.Service
{
    public class PeopleService
    {
        private IPeopleEndpoint _peopleEndpoint;
        private PhoneNumberUtil _phoneNumberUtil;
        public PeopleService(IPeopleEndpoint peopleEndpoint)
        {
            _peopleEndpoint = peopleEndpoint;
            _phoneNumberUtil = PhoneNumberUtil.GetInstance();
        }

        public IEnumerable<PersonModel> GetAnswerToCodingAssessment()
        {
            var ids = this.GetAllIds();
            var people = this.GetFromIds(ids);
            return people.Where(p => _phoneNumberUtil.IsPossibleNumber(p.Number, "US"))
                .OrderBy(p => p.Age)
                .Take(5)
                .OrderBy(p => p.Name);
        }

        public IEnumerable<int> GetAllIds()
        {
            return new PersonListEndpointResultEnumerable(_peopleEndpoint).SelectMany(r => r.Result);
        }

        public IEnumerable<PersonModel> GetFromIds(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                if (this.TryGetPerson(id, out PersonModel person))
                    yield return person;
            }
        }

        public bool TryGetPerson(int id, out PersonModel personModel)
        {
            try
            {
                personModel = _peopleEndpoint.GetPerson(id).Result;
                return true;
            }
            catch
            {
                personModel = null;
                return false;
            }
        }
    }
}
