INCLUDE globals.ink

-> main

=== main ===
huh? Ah! Desculpa, não te vi se aproximando #name:Isac #character:character
* [Você está bem?]
Não exatamente, bem, sou Isac, um dos integrantes do Conselho, fui eu que precisei dar as más notícias, mas eu mesmo não consigo acreditar nela até agora. #name:Isac

-> main2

* [Você é Isac? Do Conselho]
Sim sou eu, acho que me reconhece como o anunciante das más notícias, eu mesmo não consigo acreditar nela até agora. #name:Isac

-> main2

=== main2 ===

Precisei tomar um tempo ao ar livre para processar as coisas, logo voltarei junto com o resto do Conselho para vermos o que vamos fazer. #name:Isac

Mas não consigo deixar de pensar, será mesmo que tem algo que possamos fazer? Não tem onde se esconder nessa ilha, e afundamos na água tão fácil quanto pedra, talvez tudo esteja perdido. #name:Isac

* [Podemos não conseguir sozinhos, mas e se juntarmos todos os clãs?]
-> falar

* [Ei, vamos conseguir resolver essa situação ok?]

Você acha? Mas como?
-> vamosResolver

* [Devemos pelo menos tentar]
-> tentar

=== falar ===

Hmm, pode ser uma boa ideia, mais cabeças pensam melhor e trabalham mais rápido, mas acho difícil acontecer, não com tantos conflitos recentes entre os clãs, e não acho que o Conselho irá concordar com a maioria vendo os outros clãs como obstáculos. #name:Isac

	* [Eu estou indo falar com Kerak para convencê-lo]

	Você vai? Bem, nesse caso acho que posso te dar uma ajudinha, sabe, jogar a ideia no ar até que você chegue, talvez eles considerem em uma situação de vida ou morte #name:Isac
	->fim

	* [Você não consegue convencê-los?]
		
		Isac: O que? Não! Eu sou o membro mais novo do Conselho, não consigo nem me manter de pé com essa notícia, e vou conseguir convencer eles a largarem décadas de conflitos para fazerem as pazes? Eu não tenho a menor chance.
		-> IsacConvencer
		
=== IsacConvencer ===
		* [E se eu for conversar com eles?]

		Você vai? Bem, nesse caso talvez eu possa ajudar um pouco, jogar a ideia no ar para começar a ser considerada antes de você chegar, diminuiria a conversa que você precisaria fazer.
		-> fim
		
		* [Parece que vou ter que fazer isso sozinho.]
		
		Bem, boa sorte com isso.
		->END

=== vamosResolver ===

	* [Vou falar com Kerak sobre decidirmos algo com todos os clãs]

Você vai? Bem, nesse caso acho que posso te dar uma ajudinha, sabe, jogar a ideia no ar até que você chegue, talvez eles considerem em uma situação de vida ou morte.
->fim


=== tentar ===
	Sim, ainda precisamos ver nossas possibilidade.

	* [E se resolvermos algo junto com todos os clãs?]
-> falar


=== fim ===

~ FalouIsac = true

Obrigado por me dar pelo menos um pouco de esperança, vou avisar Kerak que você está vindo. #name:Isac


->END