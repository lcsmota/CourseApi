# CourseApi

<div align="center">
<img src="https://user-images.githubusercontent.com/118696036/229659578-ddff9d10-e9a8-4f92-bfd2-7ce780f66d40.png">
<img src="https://user-images.githubusercontent.com/118696036/229659590-0052ce1f-d57b-42dc-b7bf-4a2bd210c8bc.png">
<img src="https://user-images.githubusercontent.com/118696036/229659594-ff05cb4e-b78c-49c9-95ae-9f38d68ec9d2.png">
<img src="https://user-images.githubusercontent.com/118696036/229659604-cd1f262f-4bac-4d52-833f-50bdbe545b64.png">
</div>

#
## <img src="https://icon-library.com/images/database-icon-png/database-icon-png-13.jpg" width="20" /> Database

_Create a database in SQLServer that contains the table created from the following script:_
```sql
CREATE DATABASE CourseApiDapper

Use CourseApiDapper

CREATE TABLE Courses(
    Id INT PRIMARY KEY IDENTITY NOT NULL,
    Nome VARCHAR(80) NOT NULL,
    Categoria VARCHAR(30) NOT NULL,
    OferecidoPor VARCHAR(20) NOT NULL,
    Descricao VARCHAR(255) NOT NULL,
    Turno VARCHAR(10) NOT NULL,
    CargaHoraria SMALLINT NOT NULL,
    Observacao VARCHAR(40),
    EOnline BIT NOT NULL
);

CREATE TABLE Students(
    RA INT PRIMARY KEY IDENTITY NOT NULL,
    Nome VARCHAR(80) NOT NULL,
    Idade SMALLINT NOT NULL,
    Endereco VARCHAR(120) NOT NULL,
    Telefone VARCHAR(20) NOT NULL,
    CursoId INT NOT NULL,

    CONSTRAINT [FK_Students_Course] FOREIGN KEY(CursoId)
        REFERENCES Courses([Id])
);
```

### Relationships
```yaml
+--------------+          +--------------+
|    Courses   |          |   Students   |
+--------------+          +--------------+
| Id           |<-------->| RA           |
| Nome         |1        *| Nome         |
| Categoria    |          | Idade        |
| OferecidoPor |          | Endereco     |
| Descricao    |          | Telefone     |
| Turno        |          | CursoId      |
| CargaHoraria |          |              |
| Observacao   |          |              |
| EOnline      |          |              |
|              |          |              |
+--------------+          +--------------+
```

## 🌐 Status
<p>Finished project ✅</p>

#
## 🧰 Prerequisites

- .NET 6.0 or +

- Connection string to SQLServer in CourseApi/appsettings.json named as Default
#
## 🔧 Installation

`$ git clone https://github.com/lcsmota/CourseApi.git`

`$ cd CourseApi/`

`$ dotnet restore`

`$ dotnet run`

**Server listenning at  [https://localhost:7199/swagger](https://localhost:7199/swagger) or [https://localhost:7199/api/v1/Students](https://localhost:7199/api/v1/Students) and [https://localhost:7199/api/Courses](https://localhost:7199/api/Courses)**

#
# 📫  Routes for Student

### Return all objects (Students)
```http
  GET https://localhost:7199/api/v1/Students
```
⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229661866-d655d1cf-e5b9-4e96-bfe4-9d60dde99a43.png" />
<img src="https://user-images.githubusercontent.com/118696036/229660466-890d5fbe-6e34-44a3-ab1a-1072ad74049f.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229662344-b1e0787a-9299-4068-a3f6-7a44644e6600.png" />
<img src="https://user-images.githubusercontent.com/118696036/229660653-32d9584e-ada8-4b9d-acc8-81db61bececd.png" />

#
### Return only one object (Student)

```http
  GET https://localhost:7199/api/v1/Students/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to view|

⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229662025-f6f897b4-6f1a-4bf3-9f7b-453db1351d95.png" />
<img src="https://user-images.githubusercontent.com/118696036/229660466-890d5fbe-6e34-44a3-ab1a-1072ad74049f.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229662463-2a22ca1e-052d-4629-b05f-bb0c74a99a86.png" />
<img src="https://user-images.githubusercontent.com/118696036/229660653-32d9584e-ada8-4b9d-acc8-81db61bececd.png" />

#
### Insert a new object (Student)

```http
  POST https://localhost:7199/api/v1/Students
```
📨  **body:**
```
{
  "nome": "Juca Monteiro",
  "idade": 32,
  "endereco": "Rua 18",
  "telefone": "33333333",
  "cursoId": 1
}
```

🧾  **response:**
```
{

  "ra": 25,
  "nome": "Juca Monteiro",
  "idade": 32,
  "endereco": "Rua 18",
  "telefone": "33333333",
  "cursoId": 1
}
```

⚙️  **Status Code:**
```http
  (201) - Created
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229817127-231a6e13-96f6-463f-87ba-22423dabf40b.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229817577-6e496d4d-4d6f-4525-8b5a-90e33a78654a.png" />
<img src="https://user-images.githubusercontent.com/118696036/229817602-5b12f9e2-4c67-4e22-bea6-7c0b20587c19.png" />

#
### Update an object (Student)

```http
  PUT https://localhost:7199/api/v1/Students/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to update|

📨  **body:**
```
{
  "nome": "Juca Monteiro",
  "idade": 32,
  "endereco": "Rua 18",
  "telefone": "333-333"
}
```
🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229818265-37d4f635-76c3-4f2d-92c6-7278074b91ef.png" />
<img src="https://user-images.githubusercontent.com/118696036/229660466-890d5fbe-6e34-44a3-ab1a-1072ad74049f.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229818714-e15a7a17-d294-4e91-b790-d3bd40680da4.png" />
<img src="https://user-images.githubusercontent.com/118696036/229818730-941c06c2-47f4-49c6-8eee-ee5ea2c00f79.png" />
<img src="https://user-images.githubusercontent.com/118696036/229660653-32d9584e-ada8-4b9d-acc8-81db61bececd.png" />

#
### Delete an object (Student)
```http
  DELETE https://localhost:7199/api/v1/Students/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to delete|

📨  **body:**

🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229662161-49aa9cb1-41e2-460e-9de0-4f055c77cf4f.png" />
<img src="https://user-images.githubusercontent.com/118696036/229660466-890d5fbe-6e34-44a3-ab1a-1072ad74049f.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229662614-91b5951b-212a-40de-8d39-5e76a8634456.png" />
<img src="https://user-images.githubusercontent.com/118696036/229660653-32d9584e-ada8-4b9d-acc8-81db61bececd.png" />

#
#
# 📫  Routes for Course

### Return all objects (Courses)
```http
  GET https://localhost:7199/api/Courses
```
⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229664576-64d139f2-a88a-4e42-99f9-b95e5eae9df4.png" />
<img src="https://user-images.githubusercontent.com/118696036/229661200-3c3f3c1f-f269-4703-b3e7-e74a92f85f5b.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229665756-59a3f115-0fbe-4c52-b557-a7a68a096677.png" />
<img src="https://user-images.githubusercontent.com/118696036/229661427-23935287-7ecf-434a-be25-a6013a35790c.png" />

#
### Return only one object (Course)

```http
  GET https://localhost:7199/api/Courses/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to view|

⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229664702-6181f7dc-1657-4a06-a28a-8860fa6bbb04.png" />
<img src="https://user-images.githubusercontent.com/118696036/229661200-3c3f3c1f-f269-4703-b3e7-e74a92f85f5b.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229665626-c60c57b8-7106-43eb-9a10-1adae0b03b9b.png" />
<img src="https://user-images.githubusercontent.com/118696036/229661427-23935287-7ecf-434a-be25-a6013a35790c.png" />

#
### Return Course with Students

```http
  GET https://localhost:7199/api/Courses/1/multipleResult
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to view|

⚙️  **Status Code:**
```http
  (200) - OK
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229665074-9a147163-6e8c-4230-abd6-c6252a544078.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229665462-a6cb1131-c133-454f-8a65-a731a2c0e665.png" />
<img src="https://user-images.githubusercontent.com/118696036/229665470-237f7f32-652c-4407-b0ca-2ce1836a3b97.png" />

#
### Return all Courses with Students

```http
  GET https://localhost:7199/api/Courses/multiplemapping
```

⚙️  **Status Code:**
```http
  (200) - OK
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229665203-63cb8b4e-8d25-493b-b6f3-7b58658fa328.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229665327-caa3e18f-b0b6-4726-8211-2c16e2f936a7.png" />

#
### Insert a new object (Course)

```http
  POST https://localhost:7199/api/Courses
```
📨  **body:**
```
{
  "nome": "Cybersecurity",
  "categoria": "Tech",
  "oferecidoPor": "FIAP",
  "descricao": "Cybersecurity aborda a introdução ao tema, criptografia, as vulnerabilidades do sistema, os riscos à segurança da informação das empresas, entre outros temas.",
  "turno": "Noturno",
  "cargaHoraria": 60,
  "observacao": "Curso gratuito e emite certificado",
  "eOnline": true
}
```

🧾  **response:**
```
{
  "id": 10,
  "nome": "Cybersecurity",
  "categoria": "Tech",
  "oferecidoPor": "FIAP",
  "descricao": "Cybersecurity aborda a introdução ao tema, criptografia, as vulnerabilidades do sistema, os riscos à segurança da informação das empresas, entre outros temas.",
  "turno": "Noturno",
  "cargaHoraria": 60,
  "observacao": "Curso gratuito e emite certificado",
  "eOnline": true,
  "students": []
}
```

⚙️  **Status Code:**
```http
  (201) - Created
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229821156-7f156710-2803-4ff4-ae7a-ed4280af34e4.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229821583-29235934-1163-4c0b-b6f4-e1b0d9da7522.png" />
<img src="https://user-images.githubusercontent.com/118696036/229821598-32c77829-87dc-4e41-b3d2-7a32a38d8344.png" />

#
### Update an object (Course)

```http
  PUT https://localhost:7199/api/Courses/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to update|

📨  **body:**
```
{
  "turno": "Matutino",
  "cargaHoraria": 60,
  "observacao": "Curso gratuito e emite certificado",
  "eOnline": true
}
```
🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229822647-6b190fae-bcef-43d8-ad7f-25cb085ca20e.png" />
<img src="https://user-images.githubusercontent.com/118696036/229661200-3c3f3c1f-f269-4703-b3e7-e74a92f85f5b.png" />


#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229822920-f5a9d7d7-4a5c-44e6-a381-06bb58247af2.png" />
<img src="https://user-images.githubusercontent.com/118696036/229823016-ed33be28-65ab-49c2-81d6-fe441a617f69.png" />
<img src="https://user-images.githubusercontent.com/118696036/229661427-23935287-7ecf-434a-be25-a6013a35790c.png" />

#
### Delete an object (Course)
```http
  DELETE https://localhost:7199/api/Courses/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to delete|

📨  **body:**

🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229823485-ac85b819-baf8-4efb-a709-151472565492.png" />
<img src="https://user-images.githubusercontent.com/118696036/229661200-3c3f3c1f-f269-4703-b3e7-e74a92f85f5b.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229823503-2889a973-7fca-474c-b3a7-2c0ff962a5eb.png" />
<img src="https://user-images.githubusercontent.com/118696036/229661427-23935287-7ecf-434a-be25-a6013a35790c.png" />

#
## 🔨 Tools used

<div>
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" width="80" />
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" width="80" />
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-plain-wordmark.svg" width=80/>
</div>

# 🖥️ Technologies and practices used
- [x] C# 10
- [x] .NET CORE 6
- [x] SQL SERVER
- [x] Dapper
- [x] Swagger
- [x] DTOs
- [x] Repository Pattern
- [x] Dependency injection
- [x] POO

# 📖 Features
Registration, Listing, Update and Removal
