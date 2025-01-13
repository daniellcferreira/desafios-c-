# Gerenciador de Alocação de Investimentos

## Descrição
Este programa calcula as alocações ajustadas de investimentos em ativos financeiros, considerando:
- Os valores de mercado de cada ativo.
- O valor total a ser investido.
- Limites mínimos e máximos de alocação para cada ativo.

O cálculo distribui o investimento proporcionalmente aos valores de mercado, garantindo que as alocações respeitem os limites estabelecidos.

## Entrada
O programa solicita ao usuário os seguintes dados:
1. **Número de ativos** (um número inteiro positivo).
2. **Valores de mercado** dos ativos, separados por vírgula (ex.: `100,200,300`).
3. **Valor total investido** (um número real positivo).
4. **Limites mínimos de alocação**, separados por vírgula (ex.: `50,50,50`).
5. **Limites máximos de alocação**, separados por vírgula (ex.: `150,150,150`).

## Saída
O programa exibe as alocações ajustadas de cada ativo, com duas casas decimais. Por exemplo:

```
Digite o número de ativos:
3
Digite os valores de mercado separados por vírgula:
100,200,300
Digite o valor total investido:
1000
Digite as alocações mínimas separadas por vírgula:
50,50,50
Digite as alocações máximas separadas por vírgula:
500,500,500
Alocações calculadas:
100.00
200.00
300.00
```

