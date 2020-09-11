# Audaces Teste
A solução está funcional, no começo encontrei um problema de lógica quando a sequência de retorno deveria repetir dois dos menores números, mas no fim acabei encontrando uma resolução que entrega o resultado esperado.

### GraphQL
Não me senti confortável para aprender GraphQL em tempo da execução do desafio.

### Banco de dados
Também por conta do prazo, optei por não usar EF, mas já utilizei no no trabalho e conheço um pouco.

### Testes
Não tenho conhecimento de ferramentas de testes para implementar, então resolvi não abordar para não atrasar a entrega.
PS.: Na cadeira de "Teste de Software" na faculdade, eu apresentei as ferramentas de teste que são nativas do VS, porém, faz um tempinho e não estava fresco na minha memória.

### Web Deploy
Tanto o serviço da API quanto o Banco de Dados estão rodando no Azure.

### API Endpoints
https://audacesapiteste.azurewebsites.net/api/sequence/  
Função principal, recebe um objeto JSON do body no seguinte formato:  
{  
    "sequence": [1,2,5,20],  
    "target": 47  
}  
Retorna a sequencia possível ou uma mensagem informando sobre a impossibilidade.  

https://audacesapiteste.azurewebsites.net/api/history/{start_date}/{end_date}  
Verifica as consultas a API realizadas dentro do período entre {start_date} e {end_date}
recebe as datas no formato yyyy-MM-dd, retorna uma lista de objetos, sendo os objetos no seguinte formato:  
o.sequencia -> sequencia recebida por parâmetro para analise;  
o.alvo -> inteiro recebido como parâmetro para analise;  
o.data_consulta -> data da realização da solicitação para a API;  
o.retorno -> retorno da API para a solicitação;  

### Tempo de desenvolvimento aproximado
6 horas
