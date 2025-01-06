# Calculadora de Salário Líquido

## Descrição
Este programa calcula o salário líquido de um funcionário com base nos seguintes parâmetros:
- **Salário base**: Valor fixo recebido pelo funcionário.
- **Horas extras**: Quantidade de horas extras trabalhadas.
- **Valor por hora extra**: Valor recebido por cada hora extra.
- **Descontos de IR**: Valor dos descontos de Imposto de Renda.
- **Descontos de INSS**: Valor dos descontos de INSS.

O cálculo considera o salário base, adiciona o valor das horas extras e subtrai os descontos de IR e INSS.

## Entrada
- O programa solicita uma entrada de texto com cinco valores separados por vírgula, na seguinte ordem:
  1. Salário base (decimal)
  2. Horas extras (inteiro)
  3. Valor por hora extra (decimal)
  4. Descontos de IR (decimal)
  5. Descontos de INSS (decimal)

### Exemplo de Entrada
```
3000,10,20,200,150
```

## Saída
- Salário líquido calculado, formatado como valor monetário.

### Exemplo de Saída
```
Salário líquido: R$ 3.250,00
```

