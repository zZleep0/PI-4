INCLUDE globals.ink

{AbriuCaixaAgua == false: 
Uma caixa fechada, não se sabe o que tem dentro #character:caixa #name:Caixa
- else:
Uma caixa aberta, cheia de recipientes com água #character:caixa #name:Caixa
}

* {AbriuCaixaAgua == true && PegouAgua == false} [Pegar água]
Recipiente com água coletado #character:Null #name: 

~PegouAgua = true
->END

* [É só uma caixa]
->END