# Gerenciador de Horários de Entrevistas

## Descrição
Este programa permite gerenciar os horários de entrevistas de candidatos, ajustando automaticamente os intervalos de tempo para evitar sobreposições. Ele recebe uma lista de entradas com o nome do candidato e os horários iniciais e finais das entrevistas e retorna uma agenda ajustada sem conflitos de horário.

## Entrada
As entradas devem ser fornecidas no seguinte formato:
```
NomeDoCandidato, HH:mm-HH:mm
```
- Uma entrada por linha.
- Pressione **Enter** em uma linha vazia para finalizar as entradas.

Exemplo de entradas:
```
João, 09:00-10:00
Maria, 09:30-10:30
Ana, 10:30-11:30
```

## Saída
A saída consiste na agenda ajustada, onde os horários são ajustados para evitar sobreposições. O formato da saída é:
```
NomeDoCandidato, HH:mm-HH:mm
```

Exemplo de saída:
```
João, 09:00-10:00
Maria, 10:00-11:00
Ana, 11:00-12:00
```

