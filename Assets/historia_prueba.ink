//variables globales, se usan en cualquier sitio
VAR NombreJugador = "MC"

VAR Agresivo = false

VAR PuntosVida = 50

//funciones externas
EXTERNAL ShowCharacter(characterName, position, mood)
EXTERNAL HideCharacter(characterName)
EXTERNAL ChangeMood (characterName, mood)
EXTERNAL SwitchSong1()
EXTERNAL SwitchSong2()
EXTERNAL ActivaCasa()
EXTERNAL ActivaTurbio()
EXTERNAL ActivaBonito()

//{ShowCharacter("Aell", "Center", "Neutral")}

->nudo1 //esto es donde empeza la historia

== nudo1 ==
Tras tu primer día como Exterminador, #pensamiento
Conseguiste acabar con éxito tu expedición #pensamiento
Los mutantes te asustan, pero pudiste enfrentar tu miedo #pensamiento
Uf, he de admitir que fue difícil y habían varios cadáveres...
Pero al fin vuelvo a casa con información de esas monstruosidades


-> nudo2

== nudo2 ==
{ActivaCasa()}
Al fin en mi casa, que ganas de tumbarme, me duele la cabeza...
{SwitchSong2()}
Ja, ¿que débil eres no? #aell
Unos sudores fríos comienzan a brotar en mi cuerpo #pensamiento
Todo comienza a darme vueltas, ¿estoy alucinando? #pensamiento

***¿Quién eres?
->Pregunta

***¡Muéstrate!
~Agresivo = true
->Amenaza


=== Pregunta ===
{ShowCharacter("Aell", "Center", "Neutral")}
Hmph, soy tu pesadilla durante los próximos días #aell
Si tienes suerte claro je #aell
->Continuacion_conver

=== Amenaza ===
{ShowCharacter("Aell", "Center", "Neutral")}

Cómo te atreves a gritarme de esa manera #aell
{ChangeMood ("Aell", "Angry")}
No te conviene cabrearme #aell
->Continuacion_conver



== Continuacion_conver ==
//{ PuntosVida < 50: Hmm huelo una skill issue por aqui}
{ChangeMood ("Aell", "Neutral")}
¿Quieres comprobar lo que el grandioso Aell puede hacer? Je #aell
¿Q-qué? ... 
Mi corazón comienza a acelerarse de manera alarmante, #pensamiento
Un dolor agudo se apodera de mi cabeza y todo mi cuerpo #pensamiento
{ChangeMood ("Aell", "Flirty")}
Jajajaja #aell
¿¡Q-qué me estás haciendo?! Ah-!
Solamente déjame divertirme un rato~ #aell
Mi cuerpo comienza a moverse por su cuenta como si no tuviera el control #pensamiento
Y por si fuera poco, esa alucinación que tengo delante me mira sonriendo #pensamiento
Tienes un cuerpo interesante #aell
¡Suéltame!

***Llamar al 112
->nudo3

***Rendirte
->badEnding1

== nudo3 ==
Consigo el control de mi mano derecha y alcanzo mi móvil #pensamiento
{ChangeMood ("Aell", "Angry")}
¿¡Qué?!
Cuando estoy a punto de llamar a la policía, mis dedos sueltan el móvil #pensamiento
¡Ugh! ¡Oye que es mi móvil!
Y a mi que me importa tu móvil, tsk #aell
¿Mi virus no te está afectando o que? #aell
¿Virus huh? Asi que eso eres... un virus mutante
{ChangeMood ("Aell", "Neutral")}
Ajá, y pienso recuperar el control completo sobre ti #aell
Hmmmm...

***¿Por qué a mi?
->WhyMe

***¿Cuales son tus motivos?
->Motivos

== WhyMe ==
{SwitchSong1()}
{ChangeMood ("Aell", "Flirty")}
Ja, lo dices como si te hubiera elegido precisamente a ti #aell
Simplemente estabas en el momento adecuado #aell
{ChangeMood ("Aell", "Shy")}
...gracias #aell
->GoodEnding

== Motivos ==
{SwitchSong1()}
{ChangeMood ("Aell", "Shy")}
¿Motivos? Eh... no me esperaba eso #aell
Solo quiero vivir #aell
->GoodEnding


== GoodEnding ==
{ActivaBonito()}
{ChangeMood ("Aell", "Neutral")}
De repente un sentimiento de curiosidad y pena me invade #pensamiento
Quizás no era tan malo como pensaba #pensamiento
Vale... ¿te puedo ayudar entonces?
¿Ahora quieres ayudarme? #aell
Sí... quizás te he juzgado demasiado pronto
{ChangeMood ("Aell", "Shy")}
Oh eh... no se que decir, no me esperaba esa respuesta #aell
{ChangeMood ("Aell", "Flirty")}
Entonces... ¿quieres que colaboremos? #aell
Quizás no sea tan malo después de todo #pensamiento

->END

== badEnding1 ==
{ActivaTurbio()}
Siento como mis fuerzas se esfuman de mi cuerpo... #pensamiento
No puedo hacer mucho más, solo limitarme a observar #pensamiento
Eres un monstruo... mi cuerpo ugh...
{ChangeMood ("Aell", "Flirty")}
Una pena je, mi virus te está consumiendo muy rápido #aell
¿... virus?
Efectivamente, estás infectado, despídete de tu cuerpo #aell
Mis fuerzas y mi consciencia se apagan al rendirme ante este virus... #pensamiento
->END




