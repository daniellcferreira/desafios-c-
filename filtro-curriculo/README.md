# Filtro de Currículos

## Descrição
Este programa filtra uma lista de currículos com base em palavras-chave fornecidas. Ele é útil para selecionar currículos relevantes em processos de recrutamento e seleção, garantindo que apenas os currículos que contêm todas as palavras-chave especificadas sejam exibidos como resultado.

O programa é interativo e solicita ao usuário que insira as informações no formato correto. Ele valida a entrada e fornece mensagens claras em caso de erros ou se nenhum currículo relevante for encontrado.

## Entrada
A entrada deve ser fornecida no seguinte formato:

```
curriculo1,curriculo2,curriculoN; palavra1,palavra2,palavraN
```

- **Currículos:** Uma lista de textos separados por vírgulas, onde cada texto representa um currículo.
- **Palavras-chave:** Uma lista de palavras ou frases separadas por vírgulas, que serão usadas como critérios para filtrar os currículos.

### Exemplo de Entrada
```
"Analista de Sistemas,Desenvolvedor Fullstack; C#, SQL, JavaScript"
```

## Saída
O programa retorna:

1. **Lista de currículos relevantes:** Se um ou mais currículos atenderem aos critérios, eles serão exibidos separados por ponto e vírgula (`;`).

2. **Mensagem informativa:** Caso nenhum currículo seja encontrado, o programa exibe a mensagem:

```
Nenhum currículo relevante encontrado.
```

### Exemplo de Saída
**Entrada:**
```
"Analista de Sistemas,Desenvolvedor Fullstack; C#, SQL, JavaScript"
```

**Saída:**
```
Currículos relevantes encontrados:
Desenvolvedor Fullstack
```

**Entrada sem resultados:**
```
"Analista de Sistemas,Desenvolvedor Frontend; Python, AWS"
```

**Saída:**
```
Nenhum currículo relevante encontrado.
```

## Observações
- O programa é case-insensitive, ou seja, não diferencia letras maiúsculas e minúsculas ao comparar palavras-chave com os currículos.
- Certifique-se de seguir o formato de entrada para evitar erros.

