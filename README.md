# MESOPCServerMinimalAPI

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
Este projeto está licenciado sob a Licença MIT.

## Contato
Para suporte ou feedback, entre em contato com andre.filho@radixeng.com.

## Exemplos
Aqui estão alguns exemplos de uso da API:

(Inserir imagem exemplo)

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
