# Dynamo DB cheat sheet

## Run Dynamo DB locally

### Start local Docker instance

    docker run -p 8000:8000 amazon/dynamodb-local -jar DynamoDBLocal.jar -inMemory -sharedDb

### Create schema from schema file

    aws dynamodb create-table --cli-input-json file://dynamo-db-schema.json --endpoint-url http://localhost:8000

### Look at all the data

    aws dynamodb scan --table-name SystembolagetReleases --endpoint-url http://localhost:8000

## Dynamo DB prod

### Create schema from schema file

    aws configure
    aws dynamodb create-table --cli-input-json file://dynamo-db-schema.json