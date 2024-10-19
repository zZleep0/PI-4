INCLUDE globals.ink

Oh! Olá cavalheiro, gostaria de jogar um jogo comigo? Eu vou esconder essa bolinha em um dos copos e depois misturar, se você acertar qual dos copos ela está eu te conto um segredo #character:character #name:Desconhecido
Bem, lá vai, em qual dos copos a bolinha está?
    * [No copo da Esquerda]
    Humm, Errou! Que pena, mais sorte da próxima vez
    * [No copo do Meio]
    Humm, Errou! Que pena, mais sorte da próxima vez
    * [No copo da Direita]
    Humm, Errou! Que pena, mais sorte da próxima vez
    * {sabeSobreEnganador == true}[Em baixo da sua manga!]
    Aquela moça que te contou não foi? Uff, bem eu prometi então devo cumprir
    Nem tudo é o que parece, uma caixa pedras não necessariamente possui apenas pedras
    Agora vaza! E não conte para ninguém como encontrar a bola
    ~ sabeSobreCaixa = true