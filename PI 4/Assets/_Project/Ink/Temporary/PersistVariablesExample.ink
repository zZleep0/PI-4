INCLUDE globals.ink

 { final_color == "": -> main | -> already_has_color}
 
=== main ===
 Você ainda não escolheu uma cor
 Volte quando estiver feito uma escolha e eu vou te dizer a cor que você escolheu!
 
 -> END

 
 === already_has_color ===
 Eu vou ler a sua alma por dentro de seus olhos e te dizer a cor que escolheu...
 { final_color:
 - "Verde":
  Sim, você escolheu a cor <color=\#00fc00>{final_color}</color>!
 - "Laranja":
  Sim, você escolheu a cor <color=\#ed8f02>{final_color}</color>!
 - "Roxo":
  Sim, você escolheu a cor <color=\#7002ed>{final_color}</color>!
 }

-> END