# MESOPCServerMinimalAPI

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

## Descrição
A MESOPCServerMinimalAPI é uma API minimalista desenvolvida em C# para coletar dados de tags do servidor OPC UA Factory Talk e devolvê-los em formato JSON. Esses dados são destinados a serem interpretados e traduzidos no MES Atlantis.

## Instalação
Para utilizar esta API, siga estas etapas:
- Clone o repositório.
- Configure as informações do servidor OPC UA e as tags desejadas no arquivo `appsettings.json`.
- Execute a aplicação.

## Uso
A API fornece um único endpoint `/opcservertags` que retorna os dados das tags configuradas no servidor OPC UA em formato JSON.

Exemplo de uso:
```bash
GET /opcservertags
```

## Contribuição
Se desejar contribuir para este projeto, por favor, abra uma issue ou envie um pull request.

## Licença

![MIT LICENCE](https://img.shields.io/badge/license-MIT-blue)

## Contato
Para suporte ou feedback, entre em contato com andre.filho@radixeng.com.

## Exemplos
Aqui estão alguns exemplos de uso da API:

### Requisição Get
![image](https://github.com/radixeng/CargillBR-MES-OPCServer-Minimal-API/assets/166434418/fa477fc3-236a-40e5-bd98-ba5dd8566ca0)

### Resposta de dados em JSON
![image](https://github.com/radixeng/CargillBR-MES-OPCServer-Minimal-API/assets/166434418/e6396cfc-f0a7-41b6-8579-b3d534a0dfdc)

### Exemplo de Log
![image](https://github.com/radixeng/CargillBR-MES-OPCServer-Minimal-API/assets/166434418/c3f86335-f2ad-458a-95ef-fed48f2c1403)

## Status
Este projeto está em desenvolvimento ativo.

## Autor
- André Lindolfo Gomez Filho

## Colaboradores
- Gabriel Jamur Medina
- Kaio dos Santos Lima
- Gabriel Santos Kohlmann

## Agradecimentos
Agradecemos à equipe de desenvolvimento da Radix e aos colaboradores Gabriel Jamur Medina, Kaio dos Santos Lima, Gabriel Santos Kohlmann, Raquel Fiorese Gama e Israel Fidelis de Lima por seu apoio durante a elaboração e execução do projeto.
