## Multiplication.Prime v1 ![.NET Core](https://github.com/devdotcore/Multiplication.Prime/workflows/.NET%20Core/badge.svg)

The purpose of this microservice is to find prime numbers in the given input N and print the multiplication table in a grid form to a text file.

**Request**

```markdown
GET /prime/{input}/multiplication
```
**Response**

```markdown
{input} = 10; /prime/10/multiplication

   *   2   3   5   7
   1   2   3   5   7
   2   4   6  10  14
   3   6   9  15  21
   4   8  12  20  28
   5  10  15  25  35
   6  12  18  30  42
   7  14  21  35  49
   8  16  24  40  56
   9  18  27  45  63
  10  20  30  50  70
  
Note - Output Text file will be generated at the location - Out/output.txt
```

**This API uses [Swagger](https://swagger.io/), so you can test its endpoint easily via browser**

### Setup
The following steps are for runnning the codebase locally on a Mac using Visual Studio Code, you find similar or better options online.

1. Download and install [.Net Core 3.1.202](https://dotnet.microsoft.com/download/dotnet-core/3.1) SDK on your machine.
2. Dowload this repo into a working directory and take latest from master branch
```markdown
git clone git@github.com:devdotcore/Multiplication.Prime.git
```
3. Open the project in [VS Code](https://code.visualstudio.com/) and build -
```markdown
dotnet build
```
4. Make sure all the test case are running -
```markdown
dotnet test
```
5. Start the project directly on VS Code or run the following command -
```markdown
dotnet run --project ./src/Multiplication.Prime/Multiplication.Prime.csproj
```
5. By default, the API will be available on https://localhost:5001
