# Deseño de Sprites

## 1. Definir o Estilo Visual

- **Estilo Principal:** Pixel art.
  - **Razón:** Cohesión estética, facilidade de animación e integración en xogos 2D.
- **Paleta de Cores:**
  - Tons cálidos (vermello, laranxa) para planetas áridos ou mineiros.
  - Tons fríos (azul, branco) para planetas xeados.
  - Tons naturais (verde, marrón) para planetas con vexetación.

---

## 2. Categorizar os Sprites

### a. Fondos

- **Parallax:**
  - Capa próxima: Elementos con máis detalles e maior velocidade.
  - Capa intermedia: Elementos con menos detalles e velocidade moderada.
  - Capa distante: Elementos nebulosos ou abstractos cunha velocidade mínima.
- **Ferramentas recomendadas:**
  - **Photoshop** para crear os sprites ou **Asset Store** para descargalos.
  - Dividir as imaxes grandes en **tiles** (Sprite Editor de Unity).

---

### b. Elementos da Escena

- **Tilemaps:**
  - Crear con sprites individuais para o terreo, plataformas, trampas e decoracións.
- **Exemplos:**
  - Terreo árido (textura industrial).
  - Tundra xeada (tons brancos con brillo).
  - Mina abandonada (raíles rotos, plataformas afundidas).
- **Ferramentas recomendadas:**
  - Unity Sprite Editor para organizar tiles.
  - Grid en Unity para compoñer as escenas.

---

### c. Obxectos Interactivos

- **Combustible:**
  - Crear caixas con texturas de madeira e metálicas, e cristais animados con oscilación suave.
  - Crear animacións de explosión para as caixas ao ser recolectadas.
- **Trampas:**
  - Elementos específicos de cada planeta (picas, cogomelos radiactivos, láseres).
 

---

### d. Personaxes

- **Astro (o xogador):**
  - Crear animacións específicas:
    - Camiñar.
    - Saltar (pouso e caída).
    - Quedar inmóbil.
  - Deseñar sprites para representar vidas no HUD.
- **Robots:**
  - Deseñar diferentes modelos para cada fase.
  - **Animacións:**
    - Movemento de ida e volta.
    - Disparos (proxectís).
    - Colisións.

---

### e. Nave Espacial

- Crear un sprite base para a nave.
- Crear animacións adicionais:
  - Movemento de despegue.
  - Propulsión desde as tobeiras.
- Dividir a animación de despegue en fases para sincronizala co estado do combustible.

---

### f. Pantalla de Inicio e Final

- **Inicio:**
  - Texto animado con simulación de escritura.
  - Imaxes das bandeiras como botóns.
- **Final:**
  - Planeta Terra estático ou rotatorio.
  - Estrelas en movemento de fondo.
  - Nave movéndose en diferentes direccións.

---



## 3. Detalles Específicos por Fase

### Fase 1
- **Ambiente:** Tons cobrizos, planeta árido.
- **Obxectos:** Combustible (caixas rústicas e cristais brillantes).

### Fase 2
- **Ambiente:** Tons verdes, planeta vexetal.
- **Decoración:** Cova con tiles naturais e animacións de flora.

### Fase 3
- **Ambiente:** Tons brancos e azulados, planeta xeado.
- **Elementos Distintivos:** Serras animadas cunha rotación continua.

### Fase 4
- **Ambiente:** Tons terrosos e amarelos, planeta mineiro.
- **Decoración:** Raíles rotos, cogomelos radiactivos, estalactitas de diamante.

---

## 4. Ferramentas para Creación de Sprites

- **Aseprite:** Ideal para pixel art e animacións curtas.
- **Photoshop:** Para edición de sprites e efectos máis complexos.
- **Unity Sprite Editor:** Para cortar sprites grandes en tiles ou frames de animación.
- **IA (como DALL·E ):** Para deseñar elementos complexos, como planetas ou robots.
 

# Índice de Sprites Usados

## 1. Fondos

## Pantalla de Inicio
- **Nome:** Fondo inicial
- **Fonte:** Asset Store
- **Resolución:** 2048x2048
- **Descrición:** Fondo dinámico con efecto de desprazamento vertical.
- **Capas:**
  - **Capa única:** Sprite dunha galaxia en movemento (fondo fixo sen superposicións).
- [Sprite de Fondo pantalla inicio](../img/Space.png)

- **Fase 1:**
  - Nome: Fondo árido
  - Fonte: IA (DALL-E )
  - Descrición: Paisaxe con tons vermellos e montañas cobrizas.
  - **Capas de Parallax:**
  - **Primeira capa:** Montañas cobrizas próximas  
    - [Montañas cobrizas](../img/redmountains.png)
  - **Segunda capa:** Paisaxe árido con montañas de tonos vermellos 
    - [Fondo fase 1](../img/redP.png)
  
- **Fase 2:**
  - Nome: Fondo vexetal
  - Fonte: Asset Store
  - Descrición: Fondo con capas de vexetación e raios de luz.
  - **Capas de Parallax:**
  - **Primeira capa:** Liña de herba  
    - [Liña de herba](../img/linhaherba.png)
  - **Segunda capa:** Troncos de árbores e arbustos  
    - [Árbores próximas](../img/troncos.png)
  - **Terceira capa:** Raios de luz e vexetación afastada  
    - [Fondo fase 2](../img/Fondo2.jpg)
- **Fase 3:**
  - Nome: Fondo xeado
  - Fonte: itch.io
  - Descrición: Paisaxe branca con montañas xeadas.
  - - **Capas de Parallax:**
  - **Primeira capa:** Tundra próxima  
    - [Tundra próxima](../img/tundra.png)
  - **Segunda capa:** Montañas xeadas medias  
    - [Montañas medias](../img/mont1.png)
  - **Terceira capa:** Montañas xeadas afastadas  
    - [Montañas afastadas](../img/mont2.png)
  - **Cuarta capa:** Fondo nebuloso branco  
    - [Neve distante](../img/IceMont.png)
- **Fase 4:**
  - Nome: Fondo mineiro
  - Fonte: IA (DALL-E)
  - Descrición: Paisaxe de tons amarelos con terreo rocoso.
  - **Capas de Parallax:**
  - **Primeira capa:** Terreo rocoso elevado  
    - [Rochas próximas](../img/rocky.png)
  - **Segunda capa:** Montañas amarelas afastadas  
    - [Montañas amarelas](../img/yellowP.png)

---

## 2. Personaxes
- **Astro (Player):**
  - Nome: Astro
  - Fonte: Asset Store
  - Resolución: 160x160(cada frame de animación)
  - Descrición: Sprite animado para camiñar, saltar e quedar inmóbil.
  - Player
    - [Astro quieto](../img/Astro.png)
    - [Astro camiña](../img/AstroWalk.png)
    - [Astro salta](../img/AstroJump.png)


- **Robots:**
  - Nome: Robot (variantes Fase 1)
  - Fonte: IA (DALL-E)
  - Descrición: Sprite con movemento e prefab de disparo.
  - Variacións: Modificados para cada fase.
  -  [Robot](../img/Robot8.png)
  -  [Robot](../img/Robot7.png)
  -  [Robot](../img/Robot9.png)
  -  [Robot](../img/Robot12.png)
  -  [Robot](../img/Robot6.png)
  -  [Robot](../img/Robot10.png)

  - Nome: Robot (variantes Fase 2)
  - Fonte: IA (DALL-E)
  - Descrición: Sprite con movemento e prefab de disparo.
  - Variacións: Modificados para cada fase.
  - [Robot](../img/Robot6.png)
  - [Robot](../img/Robot14.png)
  - [Robot](../img/Robot13.png)
  - [Robot](../img/Robot15.png)
  - [Robot](../img/Robot10.png)
  - [Robot](../img/Robot16.png)

  - Nome: Robot (variantes Fase 3)
  - Fonte: IA (DALL-E)
  - Descrición: Sprite con movemento e prefab de disparo.
  - Variacións: Modificados para cada fase.
  - [Robot](../img/Robot1.png)
  - [Robot](../img/Robot2.png)
  - [Robot](../img/Robot4.png)
  - [Robot](../img/Robot6.png)
  

  - Nome: Robot (variantes Fase 4)
  - Fonte: IA (DALL-E)
  - Descrición: Sprite con movemento e prefab de disparo.
  - Variacións: Modificados para cada fase.
  - [Robot](../img/Robot3.png)
  - [Robot](../img/Robot11.png)
  - [Robot](../img/Robot22.png)
---

## 3. Obxectos Interactivos
- **Combustible:**
  - Nome: Caixa metálica (Fase 1, Fase 4)
  - Fonte: Asset Store
  - Descrición: Caixa con animación de explosión e son de explosión.
  - [Caixa](../img/Box_01.png)
 
  - Nome: Caixa metálica (Fase 2)
  - Fonte: Asset Store
  - Descrición: Caixa con animación de explosión e son de explosión.
  - [Caixa](../img/Box_02.png)
 
  - Nome: Caixa de madeira (Fase 5)
  - Fonte: Asset Store
  - Descrición: Caixa con animación de explosión e son de explosión.
  - [Caixa](../img/Box_05.png)
 
  - Nome: Cristal brillante (todas as fases)
  - Fonte: Asset Store
  - Descrición: Cristal animado con oscilación vertical e son cando o player a toca.
  - [Cristal](../img/Crystal_03.png)
   
- **Trampas:**
  - Nome: Picas (Fase 1)
  - Fonte: Asset Store
  - Descrición: Sprite estático.
 - [Picas](../img/Spike_01.png)

  - Nome: Plantas e vexetación (Fase 2)
  - Fonte: itch.io
  - Descrición: Sprite estático.
  - [Herba](../img/grass.png)
  - [Flores](../img/flores.png)


  - Nome: Láser de picas (Fase 3)
  - Fonte: itch.io
  - Descrición: Sprite animado con brillo perigoso.
  - [Láser](../img/laser_spikes_idle.png)

  - Nome: Bidón radiactivo (Fase 3)
  - Fonte: itch.io
  - Descrición: Sprite estático.
  - [Bidón](../img/decor_01.png)


  - Nome: Cogomelos radiactivos e estalacmitas de diamante(Fase 4)
  - Fonte: itch.io
  - Descrición: Sprite estático.
  - [Cogomelos e estalacmitas](../img/traps4.png)


  - Nome: Estalactitas de diamante (Fase 4)
  - Fonte: itch.io
  - Descrición: Sprite estático.
  - [Estalactitas](../img/trapsEstalacM.png)


  - Nome: Estructuras rocosas (Fase 4)
  - Fonte: itch.io
  - Descrición: Sprite estático. 
  - [Estructura rocosa](../img/rocas.png)

---

## 4. Interface
- **Barra de combustible:**
  - Nome: Indicador de combustible
  - Fonte: Photoshop
  - Descrición: Sprite animado que se enche en proporción ao progreso.
  - [Barra combustible llena](../img/fuel.png)
  - [Barra combustible vacía](../img/BOF.png)


- **Vidas:**
  - Nome: Mini Astro
  - Fonte: Derivado do sprite de Astro
  - Descrición: Iconas que representan as vidas restantes.
  - [Vidas](../img/Vidas.png)

---

## 5. Nave Espacial
- **Nave Espacial:**
  - Nome: SpaceShip
  - Fonte: Asset Store
  - Descrición: Sprite con animacións de propulsión e despegue.
  - [Nave espacial](../img/SpaceShip.png)