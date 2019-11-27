# Dotnet Lambda Function AWS

Ejemplo de un webapi usando serverless framework

## Pre-install
- Install serverless-framework (With nodejs and npm)
- Install awscli (Python)
- Install dotnet (core > 2.1)


## Tool install
```sh
dotnet tool install --global Amazon.Lambda.Tools --version 3.0.1
dotnet tool update -g Amazon.Lambda.Tools
```
# Lifecycle

## Run locally
```sh
cd FuncLambda
dotnet restore
dotnet run
```

## Runner tests 
```sh
cd FuncLambdaTest
dotnet test
```

## Verify Pact
```sh
cd PactVerify
dotnet test
```
## Build
```sh
cd FuncLambda
./build.ps1
```

## Deploy
```sh
cd FuncLambda
serverless deploy -v -p microservice
```

# Documentation

## Update definitions
```sh
aws apigateway import-rest-api --body file://swagger.json --region us-east-1
```

```sh
aws apigateway put-rest-api --rest-api-id <ID-API-GATEWAY> --mode overwrite --body file://swagger.json --region us-east-1
```

## Create Stage Mock
```sh
aws apigateway create-deployment --rest-api-id <ID-API-GATEWAY> --stage-name mock --region us-east-1
```


