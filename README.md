# Filters By Criteria example
The current repository shows an implementation of filtering by Criteria using a DDD approach

## How to run
Execute the following command on the root folder

``dotnet build & dotnet run --project apps/WebApi/WebApi.csproj``

## Examples
### Order
``https://localhost:5001/items?order=desc&order_by=name``

### Limit
``https://localhost:5001/items?limit=10``

### Offset
``https://localhost:5001/items?offset=5``

### Fields
``https://localhost:5001/items?filters[0][field]=name&filters[0][operator]=CONTAINS&filters[0][value]=item``

## Field operators
````
EQUAL           = "=="
NOT_EQUAL       = "!="
GT              = ">"
LT              = "<"
CONTAINS        = "CONTAINS"
NOT_CONTAINS    = "NOT_CONTAINS"
````



