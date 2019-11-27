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

## 1. Run locally
### Workspace /FuncLambda
```sh
dotnet restore
dotnet run
```

## 2. Runner tests 
### Workspace /FuncLambdaTest
```sh
dotnet test
```

## 3. Verify Pact
### Workspace /PactVerify
```sh
dotnet test
```
## 4. Build
### Workspace /FuncLambda
```sh
./build.ps1
```

## 5. Deploy
### Workspace /FuncLambda
```sh
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


