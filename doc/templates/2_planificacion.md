# FASE DE PLANIFICACIÓN DO PROXECTO

## Obxectivos do proxecto

## Guía de planificación do proxecto

### Metodoloxía

Para levar a cabo o traballo no proxecto **InterGalax**, empregaremos unha metodoloxía **Áxil** (ou **Agile**), que se caracteriza por ser flexible, iterativa e centrada no cliente, permitindo adaptar o proxecto ás necesidades cambiantes e ao feedback obtido durante o proceso de desenvolvemento. As principais características desta metodoloxía inclúen:

#### 1. **Enfoque iterativo e incremental**:
- O desenvolvemento do xogo dividirase en **sprints** (ciclos curtos de traballo), normalmente de dúas a catro semanas, ao final de cada sprint, entregaremos unha versión funcional do xogo, permitindo realizar melloras baseadas no feedback recibido.
- Cada sprint terá un conxunto de **funcionalidades concretas** que se van desenvolver, probar e integrar ao final do ciclo. Isto permitirá realizar axustes rápidos e garantir que o xogo se desenvolve de forma progresiva.

#### 2. **Colaboración continua**:
- **Comunicación fluída** entre todos os membros do equipo de desenvolvemento, deseñadores, testers e responsables do proxecto será clave. As reunións diarias curtas permitirán facer seguimento rápido do progreso e resolver posibles obstáculos de forma inmediata.
- A colaboración cos **stakeholders** (persoas interesadas no proxecto) tamén será continua, para garantir que as funcionalidades do xogo se alineen coas súas expectativas e necesidades. Isto incluirá o feedback dos xogadores, probas internas e colaboración con influencers ou outros expertos do sector.

#### 3. **Feedback e melloras constantes**:
- Durante o desenvolvemento, realizaremos **probas regulares** do xogo para identificar áreas de mellora e corrixir erros. A retroalimentación obtida das probas con xogadores de diferentes niveis permitirá realizar melloras constantes e adaptarse ás expectativas dos usuarios.
- A metodoloxía áxil tamén fomenta a **flexibilidade** para incorporar cambios ou novas ideas que poidan mellorar a xogabilidade ou a accesibilidade do xogo, sempre tendo en conta as prioridades e os recursos dispoñibles.

#### 4. **Priorización e xestión de tarefas**:
- O traballo será organizado e priorizado a través de **taboleiros de tarefas** ou ferramentas de xestión de proxectos (como **Trello**), onde se asignarán tarefas, definiranse prazos e estableceránse prioridades de desenvolvemento. Isto facilitará un seguimento claro do progreso do proxecto e a asignación eficiente de recursos.
- O equipo revisará e axustará as prioridades de traballo ao final de cada sprint, garantindo que as funcionalidades máis importantes ou críticas se implementen de forma temprana.

#### 5. **Entrega continua**:
- A metodoloxía áxil tamén promove a **entrega continua** de novas versións do xogo, que se actualizan con novas características ou melloras tras cada sprint. Isto asegura que o xogo sexa sempre funcional e que o equipo poida obter feedback constante.
- A entrega do xogo pode estar suxeita a **probas alfa e beta** para validar a experiencia do xogador antes de lanzalo ao público xeral.


### Fases planificadas

Descríbense as fases en que se divide o proxecto e as tarefas que se han levar a cabo en cada unha destas fases. Pódense indicar os recursos materiais e humanos asociados a cada tarefa ou, se son os mesmos, de maneira máis xeral.

#### **Fase 1: Estudo de necesidades e modelo de negocio**

##### **Tarefa 1: Investigación de mercado e definición do público obxectivo**
- **Descrición**: Realizar unha análise exhaustiva do mercado para identificar xogos de plataformas 2D similares, tanto no estilo visual como na mecánica de xogos. Recoller información sobre as preferencias dos xogadores (por exemplo, xogadores de plataformas retro, xogadores de acción rápida, etc.). A través da investigación en Steam, itch.io e foros especializados, xerar un perfil do público obxectivo, as súas expectativas e os puntos de venda máis relevantes para o xogo.
- **Accións concretas**:
  - *Analizar xogos similares en Steam e itch.io.*
  - *Realizar enquisas ou entrevistas a xogadores potenciais (podería usarse Google Forms ou plataformas de sondaxes).*
  - *Revisar foros de xogadores e críticas de xogos para obter feedback directo.*
  - *Crear un informe co perfil de xogador ideal e as súas necesidades.*
- **Recursos hardware/software**: 
  - *Plataforma de enquisas: Google Forms ou SurveyMonkey.*
  - *Software para análise de xogos: Steam e itch.io.*
- **Recursos humanos**: Xestor de proxecto, analistas de mercado
- **Duración**: 2 semanas (repartido entre a investigación e a elaboración do informe).

##### **Tarefa 2: Definición do modelo de negocio e monetización**
- **Descrición**: Decidir o modelo de monetización do xogo, tendo en conta as tendencias do mercado e as necesidades do público obxectivo. Considerar diferentes opcións, como un modelo de pago único, freemium (pago por funcionalidades adicionais) ou publicidade dentro do xogo.
- **Accións concretas**:
  - *Investigación dos modelos de monetización utilizados en xogos similares.*
  - *Crear unha estratexia de monetización que se alinee coas expectativas do público obxectivo.*
- **Recursos hardware/software**:
  - *Steamworks (para xogos de pago).*
  - *Unity Ads (para publicidade).*
- **Recursos humanos**:
  - *Xestor de proxecto.*
  - *Desenvolvedores.*
  - *Equipo de marketing.*
- **Duración**: 1 semana (análise, decisión e documentación do modelo de negocio).

#### Fase 2: Deseño e Prototipado

##### Tarefa 1: Definición do deseño do xogo (Game Design)
**Descrición:**  
Redactarase o documento de deseño do xogo (GDD) que cubrirá tódolos aspectos clave do xogo, tales como as mecánicas, o fluxo de xogo, o deseño dos niveis, os obxectivos, a historia, os personaxes e os obxectos. O GDD tamén incluirá detalles sobre a interface de usuario, a música, os efectos de son e o estilo artístico, asegurando que o equipo de desenvolvemento e os posibles colaboradores teñan unha guía clara sobre o que se debe implementar no xogo.

**Accións concretas:**  
* Completar o Game Design Document (GDD):
    * Historia: A historia que segue Astro, a astronauta que debe recoller combustible en planetas abandonados por antigas colonias humanas.  
    * Mecánicas de xogo: Movemento, saltos, interaccións con trampas, obxectos e robots.  
    * Estilo gráfico e artístico: Pixel art para personaxes, fondos e animacións.  
    * Diseño de niveis: Disposición dos diferentes planetas e as súas características.  
    * Sistema de puntuación: Como se acumulan os puntos en forma de barra de fuel e como afecta á mecánica de xogo.  
    * Trampas e obstáculos: Como as trampas afectan ao xogador e como se deben implementar os robots e as trampas nos niveis.  
    * Interface de usuario: Como se presentará a barra de combustible, as vidas e as mensaxes.  
* Validar as mecánicas clave do xogo co equipo de traballo ou con xogadores de proba antes de pasar á seguinte fase.

**Recursos hardware/software:**  
* Unity para prototipado.  
* Trello para a xestión e documentación do proxecto.

**Recursos humanos:**  
* Desenvolvedores.  
* Deseñadores gráficos.  
* Deseñadores de xogos.  
* Xestor de proxecto.

**Duración:**  
* 2 semanas.

##### Tarefa 2: Prototipado e implementación das mecánicas principais
**Descrición:**  
Nesta fase, o equipo desenvolverá un prototipo funcional do xogo que incluirá as mecánicas principais, como o movemento do xogador (Astro), as interaccións cos obxectos, trampas e robots, así como a implementación inicial da barra de combustible e das vidas.

**Accións concretas:**  
* Desenvolver o prototipo básico do xogo que inclúa:
    * Movemento do xogador (andar, saltar, interaccións coa física do xogo).  
    * Mecánicas de recolección (caixas, diamantes).  
    * Sistema de puntuación e perda de vidas.  
    * Trampas que afecten ao xogador dependendo dos combustible acumulado.  
* Validar o movemento e as interaccións para asegurar que as mecánicas sexan intuitivas e non causen confusión ao xogador.

**Recursos hardware/software:**  
* Unity e Visual Studio Code (C#) para a implementación das mecánicas.  
* Asset Store e Photoshop para os primeiros gráficos e assets.

**Recursos humanos:**  
* Desenvolvedores.  
* Deseñadores gráficos.  
* Testers.

**Duración:**  
* 3 semanas.

##### Tarefa 3: Creación das assets gráficas e animacións
**Descrición:**  
Durante esta fase, crearase o material gráfico necesario para o prototipo. Isto incluirá personaxes, obxectos, fondos e animacións.

**Accións concretas:**  
* Diseñar os personaxes principais, como Astro e os robots.  
* Crear os fondos dos niveis (planetas, paisaxes, plataformas).  
* Crear animacións para o movemento do xogador, robots e efectos especiais.  
* Incorporar os assets ao xogo e probar como interactúan cos sistemas de xogo. Establecer tags e capas e habilitar ou deshabilitar as interaccións que interesen ou non interesen.

**Recursos hardware/software:**  
* Photoshop para a creación de assets en Pixel Art.  
* Unity para importar e probar os gráficos no motor de xogo.  
* Asset Store para a descarga gratuita de recursos en pixel art.  
* itch.io para a descarga de recursos para converter en tilemaps en Unity.

**Recursos humanos:**  
* Desenvolvedores.  
* Deseñadores gráficos.

**Duración:**  
* 4 semanas.

##### Tarefa 4: Implementación do sistema de física
**Descrición:**  
Nesta fase, implementarase o sistema de física para a interacción dos obxectos co xogador e a creación da animación dos robots. As interaccións entre o xogador e o ambiente (como as plataformas, trampas e obxectos) son fundamentais para a xogabilidade.

**Accións concretas:**  
* Implementar o sistema de física básico, incluíndo gravidade, colisións e movemento.  
* Crear a animación dos robots para que se despracen e disparen ao xogador cando este se acerque.  
* Probar as interaccións do xogador coas trampas e os robots.

**Recursos hardware/software:**  
* Unity para o sistema de física.  
* Visual Studio Code para programación en C#.

**Recursos humanos:**  
* Desenvolvedores.  
* Testers.

**Duración:**  
* 2 semanas.

##### Tarefa 5: Probas e optimización  
**Descrición:**  
A última tarefa da fase de prototipado é realizar probas de xogabilidade para avaliar o fluxo do xogo, as mecánicas e a experiencia do xogador. A retroalimentación obtida permitirá mellorar o prototipo antes de continuar co desenvolvemento completo.

**Accións concretas:**  
* Realizar probas de xogabilidade.  
* Optimizar o xogo para garantir un rendemento adecuado e solucionar posibles problemas de xogos ou bugs.

**Recursos hardware/software:**  
* Unity para realizar as probas de xogabilidade.

**Recursos humanos:**  
* Desenvolvedores.  
* Xogadores.

**Duración:**  
* 2 semanas.

#### Fase 3: Desenvolvemento e Implementación das Mecánicas Avanzadas

##### Tarefa 1: Implementación das mecánicas finais
**Descrición:**  
Durante esta tarefa, implementaranse as mecánicas finais que definirán a xogabilidade completa do xogo, como a interacción coas caixas, a recollida de combustible, os robots, a física avanzada de salto e colisións, entre outros.

**Accións concretas:**  
* Sistema de puntuación avanzado: Completar a integración do sistema de puntuación con efectos no xogo (recollida de combustible, perda de vidas, etc.).  
* Mecánicas de trampas e robots: Implementar as trampas específicas para cada planeta, xunto co comportamento dos robots (como disparar e detectar ao xogador).  
* Interaccións: Desenvolver as interaccións entre o xogador e os obxectos (caixas, diamantes, trampas, robots).  
* Implementación dos niveis finais: Implementar os niveis completos, con todos os obxectos, trampas e robots en cada escenario.  

**Recursos hardware/software:**  
* Unity para a implementación das mecánicas.  
* Visual Studio Code para programación en C#.  

**Recursos humanos:**  
* Desenvolvedores.  

**Duración:**  
* 3 semanas.

##### Tarefa 2: Desenvolvemento dos niveis
**Descrición:**  
A creación dos niveis no xogo, incluíndo a disposición dos obxectos, trampas, robots e a súa dificultade progressiva. Cada nivel debe ter características únicas en canto á disposición das plataformas, a localización dos obxectos e as trampas.

**Accións concretas:**  
* Deseño de niveis: Crear os niveis de xogo baseándose na planificación do GDD.  
* Dificultade: Asegurarse de que a dificultade vaia aumentando a medida que se avanza nos niveis.  
* Colocación de obxectos e robots: Situar as caixas de combustible, trampas e robots en cada nivel de forma que se adapten á mecánica de xogo.  

**Recursos hardware/software:**  
* Unity para a creación dos niveis.  
* Visual Studio Code para a programación dos comportamentos dos obxectos.  

**Recursos humanos:**  
* Desenvolvedores.  

**Duración:**  
* 2 semanas.

##### Tarefa 3: Integración da música e efectos sonoros  
**Descrición:**  
Implementación final da música de fondo e efectos sonoros que acompañen a acción do xogo. Cada interacción debe ter un son que mellore a experiencia do xogador e que se integre coas mecánicas do xogo.

**Accións concretas:**  
* Música de fondo: Integrar a música que acompañará ao xogador en cada nivel, con transiciones entre fases e momentos importantes.  
* Efectos sonoros: Asignar efectos sonoros para a interacción co xogador (recollida de obxectos, perda de vidas, trampas, etc.).  
* Sincronización: Garantir que todos os sons se reproduzan no momento adecuado e con boa calidade para evitar que se solapen ou se perdan.  

**Recursos hardware/software:**  
* Asset Store.  
* Unity para importar e asignar os sons.  

**Recursos humanos:**  
* Desenvolvedores.  

**Duración:**  
* 1 semanas.

##### Tarefa 4: Optimización e probas  
**Descrición:**  
Optimizar o xogo para garantir que funcione correctamente nas plataformas obxectivo (PC).  

**Accións concretas:**  
* Optimización gráfica: Reducir o uso de memoria e a carga gráfica sen perder a calidade visual, especialmente cando se usen fondos en parallax ou assets grandes.  
* Probas de rendemento: Realizar probas en diferentes dispositivos para garantir que o xogo funcione sen problemas en plataformas de baixo e alto rendemento.  
* Probas externas: Convidar a xogadores externos a probar o xogo e obter retroalimentación sobre a dificultade, a interface e as mecánicas.  
* Corrección de erros: Detectar e corrixir bugs que poidan estar afectando ao xogo ou aos seus recursos.  
* Recoller feedback: Implementar as melloras baseadas nas probas de xogabilidade e feedback recibido.  

**Recursos hardware/software:**  
* Unity para a optimización e probas de rendemento.  

**Recursos humanos:**  
* Desenvolvedores.  

**Duración:**  
* 2 semanas.

#### Fase 4: Probas, Depuración e Optimización Final

##### Tarefa 1: Probas de xogabilidade  
**Descrición:**  
Durante esta tarefa, realizaremos probas para asegurar que o xogo sexa divertido e desafiante, e que as mecánicas funcionen como se agarda en diferentes escenarios. As probas de xogabilidade permitirán detectar fallos de usabilidade e posibles melloras na experiencia do xogador.

**Accións concretas:**  
* Xogabilidade interna: O equipo interno xogará ao xogo, realizando probas nas diferentes fases para detectar posibles fallos ou puntos débiles na mecánica de xogo.  
* Xogadores de proba externa: Invitar a xogadores externos que non tiveron contacto previo co xogo a probar as mecánicas e recoller retroalimentación.  
* Análise de dificultade: Axustar a dificultade dos niveis, asegurándose de que sexa desafiante pero xusto para o xogador.  

**Recursos hardware/software:**  
* Unity para as probas.  
* Ferramientas de análise de xogabilidade para recoller datos e feedback.  

**Recursos humanos:**  
* Desenvolvedores.  
* Testers.  
* Xogadores de proba.  

**Duración:**  
* 2 semanas.

##### Tarefa 2: Depuración e corrección de erros  
**Descrición:**  
A depuración consiste en detectar e corrixir os erros técnicos que poidan afectar á estabilidade e funcionamento do xogo. Esta tarefa é crucial para garantir que non haxa fallos que poidan interromper a experiencia do xogador.

**Accións concretas:**  
* Corrección de bugs: Utilizar as ferramentas de depuración de Unity para identificar e resolver erros relacionados co sistema de física, control de versións, interacciones co xogador, e outras mecánicas do xogo.  
* Fixación de erros visuais e de rendemento: Corrixir problemas de visibilidade ou rendemento nos fondos, animacións ou interactividade.  
* Probas de compatibilidade: Asegurarse de que o xogo funcione correctamente en diversas plataformas (PC) e resolucións.  

**Recursos hardware/software:**  
* Unity Profiler para a depuración e optimización.  
* Visual Studio Code para a depuración de código en C#.  

**Recursos humanos:**  
* Desenvolvedores.  
* Testers.  

**Duración:**  
* 3 semanas.

##### Tarefa 3: Integración de feedback e melloras finais  
**Descrición:**  
A integración de feedback externo dos xogadores de proba e a realización de melloras finais axustará os detalles do xogo para mellorar a experiencia global do xogador e asegurar que todas as funcionalidades estean pulidas.

**Accións concretas:**  
* Mellorar a interface de usuario (UI): Optimizar a interface do xogo para facer a navegación máis intuitiva e mellorar a accesibilidade.  
* Axustes na música e sons: Asegurar que a música e os efectos sonoros se adapten ás novas mecánicas e que non interfiran na xogabilidade.  

**Recursos hardware/software:**  
* Unity para implementación de UI e melloras gráficas.  

**Recursos humanos:**  
* Desenvolvedores.  
* Testers.  

**Duración:**  
* 2 semanas.



### Diagrama de Gantt

<img src="doc/img/DiagramaGantt.png">

## Orzamento

### Orzamento por actividade

  <img src="doc/img/orzamento.png"/>

### Orzamento por partidas de inversión / gasto:

<img src="doc/img/inversion-gasto.png"/>

A) INVESTIMENTOS:

* Gastos de constitución: Inclúe custos iniciais, como licenzas de software e preparación do proxecto.
* Equipos informáticos: Inclúe hardware necesario (ordenadores, periféricos).
* Outros gastos: Recursos gráficos, ferramentas específicas como licenzas de Unity Pro.

B) GASTOS:

* Persoal: É o custo máis relevante, estimado a 20 €/hora por cada membro do equipo.
* Publicidade: Inclúe campañas en redes sociais, colaboracións con influencers e materiais promocionais.
* Outros gastos: Pequenos custos de mantemento ou servizos puntuais.




