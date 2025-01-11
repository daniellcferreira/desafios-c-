# Gerenciamento de Contratos

## Descrição
Este programa permite gerenciar contratos e calcular custos associados a eles. O usuário pode inserir dados interativamente, como orçamento disponível e informações de contratos (nome, departamento, dias de duração e valor diário). O programa calcula o custo total, verifica se o orçamento foi excedido e identifica o departamento com maior custo.

## Entrada
1. **Orçamento Total:** Um valor numérico decimal indicando o orçamento disponível.
2. **Dados dos Contratos:** Informados iterativamente, cada contrato possui os seguintes campos:
   - Nome do contrato (texto).
   - Departamento (texto).
   - Dias de duração (inteiro).
   - Valor diário (decimal).
3. Para finalizar a entrada de contratos, deixe o nome do contrato vazio e pressione Enter.

## Saída
1. **Custo Total:** Soma dos custos de todos os contratos, calculada como `Dias * ValorDiaria` para cada contrato, exibida com duas casas decimais.
2. **Status do Orçamento:** Uma mensagem indicando se o orçamento foi "Dentro do orçamento" ou "Orçamento excedido".
3. **Departamento com Maior Custo:** Nome do departamento cujo custo total foi o mais alto entre os contratos inseridos.

