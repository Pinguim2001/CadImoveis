# 🏡 CadImoveis - API de Cadastro de Imóveis

API RESTful desenvolvida em ASP.NET Core para gerenciamento de imóveis e seus proprietários, com suporte a cadastro em etapas, retomada de preenchimento, consultas e cálculo de valor por hectare.

---

## 🎯 Objetivo

Essa WebAPI permite que agências credenciadas realizem o **cadastro de imóveis em etapas**, associando-os a seus respectivos proprietários. A API contempla funcionalidades como:

- Cadastro e vínculo de proprietários e imóveis
- Registro por etapas (Proprietário → Imóvel → Finalização)
- Retomada de cadastros não finalizados
- Consulta por documento do proprietário
- Geração de resumo de cadastros finalizados
- Cálculo de valor total por área em hectares

---

## 📌 Funcionalidades

- ✅ Criar cadastro de proprietário
- ✅ Associar imóvel ao proprietário
- ✅ Marcar cadastro como finalizado
- ✅ Listar todos os cadastros com suas etapas
- ✅ Retomar cadastro interrompido
- ✅ Consultar proprietário por documento
- ✅ Obter resumo de cadastro finalizado
- ✅ Calcular valor total dos imóveis de um proprietário


---

## 🧪 Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL
- Swagger (OpenAPI)
- Injeção de Dependência (DI)
- Programação em camadas (Domain, Application, Infrastructure)

