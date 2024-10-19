INCLUDE globals.ink

{
- FalouIsa == false:
->beforeMain
- else:
->beforeRevisita
}

=== beforeMain ===
Olá Pierre! Como vai? #character:character #name:Isa
~ FalouIsa = true
->main

=== main ===

* {Isa == 0} [Eu vou bem, e você?]

Eu vou mais ótima do que nunca! Acabei de redecorar minha casa, eu te mostraria, mas ainda preciso fazer uns toques finais.

~ Isa = 1

-> main

* {Isa == 0} [Não muito bem, depois da notícia...]

Ah, sobre o vulcão? Fica tranquilo! Eu tenho certeza que Kerak vai encontrar uma solução.

~ Isa = 2

-> main

* {Isa < 2} [Você não sabe sobre a notícia recente?]

Só porque estou radiando positividade? Relaxa vai ficar tudo bem, tenho certeza que Kerak vai encontrar uma solução.

~ Isa = 2

-> main

* {Isa > 0} [Eu preciso ir]
-> fim

* {SabeAgua == true && AbriuCaixaAgua == false} [Eu preciso de água, você poderia me dar alguma?] 

~ Isa = 1
~ AbriuCaixaAgua = true
Claro! Aqui nessa caixa, vou abrir para você.
-> main

=== beforeRevisita ===
Olá novamente Pierre! Precisa de alguma coisa? #character:character #name:Isa
->revisita

=== revisita ===

* {Isa < 2} [Você não sabe sobre a notícia recente?]
Só porque estou radiando positividade? Relaxa vai ficar tudo bem, tenho certeza que Kerak vai encontrar uma solução.

~ Isa = 2

-> revisita

* {SabeAgua == true && AbriuCaixaAgua == false} [Eu preciso de água, você poderia me dar alguma?] 

Claro! Aqui nessa caixa, vou abrir para você.
~ AbriuCaixaAgua = true

-> revisita

* [Eu preciso ir]
-> fim

=== fim ===

Até mais!

->END