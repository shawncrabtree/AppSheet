DETAILS

This console application displays the 5 youngest users with a valid US telephone number, ordered by name, from the sample api.

The statement of "valid US telephone number" is a bit ambiguos. 
I used the libphonenumber-csharp Nuget Package, which is a port of Google's common library.

EXTRA CREDIT - Testing

I designed my implementation so that it can be easily unit tested and integration tested. 
The IPeopleEndpoint interface can be mocked so that we could unit test both the iteration logic of the PersonListEndpointResultIterator and enumerator, as well as all logic in the PeopleService.
Additionally, integration tests could be written against the actual sample API, or against many sample APIs.

EXTRA CREDIT - Scaling

In order to scale this application we would need a better implementation of batching. 
The "list" endpoint implements batching well, but the batch size of 10 is rather small. 
We would want to update this call to return a larger list of Ids, or possibly allow the client to specify the number of Ids they want to recieve in each batch.
The "detail" endpoint would have to be updated to implement batching.
This could be achieved by having the "detail" endpoint accept an array of people Id's and return a list of people.
Finally, we would want to avoid storing all people in memory.
So, as we make calls out to the batched "detail" endpoint, we would only keep the cumulative 5 youngest users with a valid US telephone number in memory.
Additionally, the client could be updated to asynchronously begin making calls to the "detail" endpoint as soon as we start recieving batches from the "list" endpoint, instead of waiting for all calls to the "list" endpoint to complete before starting to call the "details" endpoint.
