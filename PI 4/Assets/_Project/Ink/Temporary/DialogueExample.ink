 INCLUDE globals.ink
 
 VAR firstColor = ""
 VAR secondColor = ""
 VAR haveFirstColor = false
 
 //Dialogo de exemplo, mostrando como as linhas são separadas e como guardar variaveis e criar condições para mostrar diferentes dialogos, além de como usar Rich Text no TextMeshPro no Unity
 
 //Caso seja a primeira vez, vai para main, caso não, vai para already_has_color
 { final_color == "": -> main | -> already_has_color}
 
 === main ===
 Olá! isso é um teste #color:Branco
 Mas que tal juntarmos duas cores? Primeiro escolha a cor que você mais gosta entre essas
 -> colors
 
  === already_has_color ===
 Olá novamente, você gostaria de trocar a cor que escolheu?
 Tudo bem, escolha a primeira cor entre as que você mais gosta entre essas
 -> colors
 
 === colors ===
    * [Azul]
        {haveFirstColor == false:
        ~ firstColor = "Azul"
        Que legal, Eu também gosto de <color=\#008ffc>{firstColor}</color>! #color:{firstColor}
        - else:
        ~ secondColor = "Azul"
        }
        -> chosen
    * [Amarelo]
        {haveFirstColor == false:
        ~ firstColor = "Amarelo"
        Que legal, Eu também gosto de <color=\#c9c600>{firstColor}</color>! #color:{firstColor}
        - else:
        ~ secondColor = "Amarelo"
        }
        -> chosen
    * [Vermelho]
        {haveFirstColor == false:
        ~ firstColor = "Vermelho"
        Que legal, Eu também gosto de <color=\#fc0000>{firstColor}</color>! #color:{firstColor}
        - else:
        ~ secondColor = "Vermelho"
        }
        -> chosen
        
=== chosen ===
{haveFirstColor == false:
    Agora escolha a segunda cor
    ~ haveFirstColor = true
    -> colors
    - else:
    {firstColor + secondColor:
    - "AzulAmarelo":
        ~ final_color = "Verde"
        É isso ai <color=\#008ffc>{firstColor}</color> com <color=\#c9c600>{secondColor}</color> da <color=\#00fc00>{final_color}</color>! #color:{final_color}
    - "AmareloAzul":
        ~ final_color = "Verde"
        É isso ai <color=\#c9c600>{firstColor}</color> com <color=\#008ffc>{secondColor}</color> da <color=\#00fc00>{final_color}</color>! #color:{final_color}
    - "AzulVermelho": 
        ~ final_color = "Roxo"
        É isso ai <color=\#008ffc>{firstColor}</color> com <color=\#fc0000>{secondColor}</color> da <color=\#7002ed>{final_color}</color>! #color:{final_color}
    - "VermelhoAzul":
        ~ final_color = "Roxo"
        É isso ai <color=\#fc0000>{firstColor}</color> com <color=\#008ffc>{secondColor}</color> da <color=\#7002ed>{final_color}</color>! #color:{final_color}
    - "AmareloVermelho":
        ~ final_color = "Laranja"
        É isso ai <color=\#c9c600>{firstColor}</color> com <color=\#fc0000>{secondColor}</color> da <color=\#ed8f02>{final_color}</color>! #color:{final_color}
    - "VermelhoAmarelo":
        ~ final_color = "Laranja"
        É isso ai <color=\#fc0000>{firstColor}</color> com <color=\#c9c600>{secondColor}</color> da <color=\#ed8f02>{final_color}</color>! #color:{final_color}
    }
}


 -> END
