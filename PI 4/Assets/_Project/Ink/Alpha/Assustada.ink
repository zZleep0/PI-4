INCLUDE globals.ink

{
-SabeAgua == false:
->main
- SabeAgua == true:
->revisita
- else:
->finalisado
}
-> main

=== main ===
Oi Pierre, estou um pouco nervosa com o que está acontecendo, eu não acho que estou muito bem, você teria um pouco de água para mim? #name:Clotilde #character:character

~ SabeAgua = true

* [Fique tranquila, vamos resolver isso]

Tudo bem, mas esta situação ainda é muito estressante, vou tentar me manter calma
->END
    
* {PegouAgua == false} [Não tenho água comigo, mas posso tentar conseguir para você]

Obrigada, por favor, estarei esperando.
->END

* {PegouAgua == true} [Aqui está um pouco de água para te tranquilizar um pouco]

->kidrodrum

=== kidrodrum ===

~ FalouClotilde = true

Muito obrigada, já estou me sentindo melhor, <color=\#fc0000>kidrodrum</color> Pierre! #word:0

* [Kidro... o que?]

Haha me desculpe, é um termo da lingua do clã Lápis Lazúli, ele significa sorte e prosperidade, então eu te desejei sorte em seu caminho.

->END

* [Até mais]
->END

=== revisita ===
Oi novamente Pierre, conseguiu água para mim? #name:Clotilde #character:character

* {PegouAgua == false} [Ainda não]
Tudo bem, estarei aqui esperando
->END

* {PegouAgua == true} [Sim, aqui está]
-> kidrodrum

=== finalisado ===
Agradeço a sua ajuda Pierre, estarei para o que precisar #name:Clotilde #character:character
->END