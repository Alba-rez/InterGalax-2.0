# Proxecto fin de ciclo

>O obxectivo xeral de InterGalax é crear un videoxogo de plataformas accesible e desafiante que ofreza unha experiencia de entretenemento envolvente a través da exploración espacial, a recolección de recursos e a superación de obstáculos. O xogo estará ambientado nun universo de ciencia ficción, onde o xogador controlará a un astronauta que debe viaxar por diferentes planetas, enfrentarse a trampas e recoller combustible para regresar á Terra. A estética en pixel art combinará a nostalxia dos xogos retro cun estilo moderno e atractivo, mentres que as mecánicas intuitivas permitirán que xogadores de todas as idades poidan disfrutar da experiencia, sen que se perda a sensación de reto e diversión.

# Descripción


> Xogo de plataformas 2D onde o xogador, chamado 'Astro', ten que explorar varios planetas alieníxenas. O escenario está deseñado cun fondo en parallax, o que crea unha sensación de profundidade mentres Astro se despraza por esos mundos. O xogo conta con varios tipos de trampas que restan ombustible da barra de fuel e obxectos como caixas que dan combustible e incrementan esa barra de fuel. A mecánica principal do xogo inclúe un sistema de puntuación basado nunha barra de fuel, onde a puntuación se axusta cando o xogador interactúa cos obxectos do mundo, como as caixas e as trampas.

>Cada vez que o xogador perde unha vida, a puntuación se axusta a 0 e o xogador debe reiniciar a escena coas vidas actualizadas. O obxectivo final é avanzar polos niveis mentres se evitan os obstáculos e se consegue encher a barra de fuel para poder despegar a nave e continuar ate o seguinte planeta. A temática é futurista e alieníxena
Todo está deseñado nun estilo pixel art para darlle un toque retro e único ao xogo

# Instalación / Posta en marcha


### 1. Acceder ao Repositorio de GitLab
Accede ao repositorio de GitLab onde está almacenado o executable do xogo.
Asegúrate de estar na sección adecuada onde están os arquivos do xogo, carpeta `InterGalax > Ejecutable`.

### 2. Descargar os Arquivos
Dentro da carpeta `Ejecutable`, atoparás o arquivo executable de Windows (`Interestellar.exe`) e unha carpeta adicional chamada `Interestellar_Data` que contén todos os datos e recursos necesarios para executar o xogo.

**Pasos para descargar:**

- Fai clic na carpeta `Ejecutable` e descarga tanto o arquivo executable (`Interestellar.exe`) como a carpeta `Interestellar_Data` xunto con todos os arquivos que contén.

### 3. Manter a Estrutura de Carpetas
Non modifiques a estrutura das carpetas. É importante que o arquivo `Interestellar.exe` e a carpeta `Interestellar_Data` permanezan na mesma ubicación.

A estrutura de carpetas correcta debe ser algo así:

InterGalax/ ├── Ejecutable/ │ ├── Interestellar.exe │ └── Interestellar_Data/ │ ├── Resources/ │ ├── Plugins/ │ └── etc.


### 4. Executar o Xogo
Unha vez que descargaches os arquivos, navega ata a carpeta onde os gardaches.
Fai doble clic en `Interestellar.exe` para iniciar o xogo.

### 5. Requisitos do Sistema
Asegúrate de que o teu sistema cumpra cos seguintes requisitos:
- **Sistema operativo**: Windows 10 ou superior (recomendado).
- **Dependencias necesarias**:
  - **DirectX** (asegúrate de telo actualizado).
  - **Microsoft Visual C++ Redistributable** (se o xogo non arranca, pode que necesites instalalo).
  - **.NET Framework** (se se require).
  
Se o xogo non arranca, verifica que estas dependencias estean instaladas correctamente.
 

# Uso

> **InterGalax** é un videoxogo de aventuras no que controlas a `Astro`, unha exploradora espacial que debe avanzar a través de niveis cheos de trampas e obstáculos para conseguir combustible e poder regresar ao seu planeta.

## Na interface gráfica:

### Iniciar o xogo:
Fai doble clic no arquivo `Interestellar.exe` para comezar a xogar.

### Controis básicos:

- **Mover a Astro**: Usa as teclas `W`, `A`, `S`, `D` ou as teclas de dirección para mover a Astro polo escenario.
- **Saltar**: Pulsa a tecla `Espazo` para saltar sobre obstáculos ou trampas, e axúdate dos "Colliders" dos obxectos para ampliar ese salto ou conseguir máis impulso
- **Interacción**: Aproxímate aos obxectos da escea para interactuar con eles, por exemplo, as caixas.

### Obxectivos:

- **Obter puntos**: Destrúe as caixas e evita as trampas para acumular fuel na barra de combustible.
- **Recolección de obxectos**: Algúns obxectos, como os cristáis, dan puntos adicionáis que se converterán en combustible.

### Niveis:

- O xogo ten 4 niveis. A medida que avances, os desafíos e as trampas faranse máis difíciles.
- Os puntos acumúlanse en forma de fuel na barra de combustible e determinan a progresión dunha escea á outra.
- O xogador perde vidas ao ser alcanzado polos disparos dos robots.
- O xogo remataría con un Game Over, ben se se perden as 3 vidas, como se caes nos obxectos "serras" do nivel 3.
- O Game Over permitiríache sair do xogo, ou volver a empezar. Se o xogador está no nivel 1,2 e 3, regresaría ao nivel 1. Se o xogador está no nivel 4, regresaría ao nivel 2.

### Cambio de idioma:



### Final do xogo:

- O xogo rematará cando se esgoten as vidas ou chegues a escea final, despois de superar o nivel 4.


# Sobre o autor

> Sempre me fascinou a programación, especialmente o reto de crear algo desde cero e ver como cobra vida. O proxecto do videoxogo foi unha elección natural para min, xa que foi no que máis me divertín e sentín realizada durante o ciclo de Desenvolvemento de Aplicacións Multiplataforma. Non obstante, en tódalas asignaturas atopei moita satisfacción en aprender e descubrir novas ideas. A miña curiosidade e o desexo de afrontar novos retos definen a miña forma de ser: son unha persoa proactiva, apaixonada por aprender e mellorar constantemente, sempre buscando o próximo desafío que me permita crecer tanto a nivel profesional como persoal

# Licenza

>  *GNU Free Documentation License Version 1.3*. 


# Índice

>

1. Anteproxecto
    * 1.1. [Idea](doc/templates/1_idea.md)
    * 1.2. [Necesidades](doc/templates/0_necesidades.md)
2. [Planificación](doc/templates/2_planificacion.md)
3. Deseño
   * 3.1. [Diagrama de clases](doc/templates/3_diagrama_clases.md)
   * 3.2. [Diagrama de fluxo](doc/templates/4_diagrama_fluxo.md)
   * 3.3. [Diagrama de navegación](doc/templates/5_diagrama_nav.md)
   * 3.4. [Deseño de sprites](doc/templates/6_dis_sprites.md)
   * 3.5. [Casos de uso](doc/templates/7_casos_uso.md)
   * 3.6. [Mockup deseño visual](doc/templates/9_mockup_deseño.md)
   * 3.7. [GDD](doc/GDD.md)
4. Implantación
   * 4.1. [Manual Técnico](doc/templates/10_manual_tecnico.md)
   * 4.2. [Futuras Melloras](doc/templates/11_futuras_melloras.md)
   * 4.3. [Dificultades e reflexión](doc/templates/12_dificultades_reflexion.md)
   * 4.4. [Resumo](doc/templates/13_resumo.md)
5. [Manual de Usuario](doc/templates/14_manual_usuario.md)

6. [Proxecto de Unity](InterGalax)

7. Setup
   * 7.1. [Manual de instalación](doc/templates/16_manual_instalacion.md)
   * 7.2. [Executable](InterGalax/Ejecutable/Interestellar.exe)

8. [Licenza](LICENSE)


# Guía de contribución

> Agradezo tódalas contribucións ao proxecto **InterGalax**! Se desexas colaborar, aquí che deixo algúns xeitos de facelo:

## Como Contribuír

### 1. Clonar o Repositorio

- Clona o repositorio no teu ambiente local para comezar a traballar nas túas melloras.

### 2. Crear unha Nova Rama

- Crea unha nova **rama** para o teu cambio ou mellora.
- Nomea a rama de forma clara e específica (por exemplo, `feature-novo-nivel` ou `fix-correccion-bug`).
- As melloras e correccións deben ser feitas nunha **rama separada** da principal (`master` ou `main`).

### 3. Facer Cambios e Testar

- Realiza os cambios que consideres necesarios, xa sexan novas funcionalidades, correccións de erros, melloras de rendemento ou cambios na interface.
- Asegúrate de que os cambios **non rompan a funcionalidade existente**. Cando sexa posible, engade **probas** para verificar a súa implementación.

### 4. Enviar un Pull Request

- Unha vez que termines, realiza un **pull request** para a rama principal do proxecto.
- Expón claramente na **descrición do pull request** o que fixeches e os cambios que se realizaron. Se engadiches novas funcionalidades ou fixeches cambios importantes, explícaos detalladamente.

## Que tipo de contribucións son benvidas?

- **Novas funcionalidades**: Se tes ideas para engadir novas mecánicas ou funcionalidades ao xogo, non dubides en compartilas.
- **Correccións de erros**: Se atopas erros ou fallos no xogo, podes contribuír creando un "issue" ou enviando un pull request co código de corrixido.
- **Optimizacións**: Se ves que algunha parte do código pode mellorar en termos de rendemento ou eficiencia, sería unha gran contribución.
- **Melloras na documentación**: Axudar a mellorar a documentación é fundamental para que outros desenvolvedores e xogadores poidan entender mellor o proxecto.
- **Melloras na interface ou experiencia de usuario**: Se tes ideas para mellorar a interface ou engadir novos elementos que melloren a experiencia de xogo, estas contribucións son benvidas.

## Normas de colaboración

- **Código limpo e ben documentado**: Asegúrate de que o código estea ben estruturado e documentado. Comenta o código cando sexa necesario para facilitar a comprensión.
- **Seguir a nomenclatura existente**: Mantén a coherencia co estilo e as convencións de nomenclatura do proxecto.
- **Revisión de código**: Un membro do equipo revisará o teu pull request antes de integralo. A revisión é importante para garantir a calidade do código e evitar posibles problemas.

# Links

> ## Enlaces útiles

> - **[Unity - Motor de xogo](https://unity.com/)**  
  A páxina oficial de **Unity**, o motor de xogo que se utiliza para o desenvolvemento de **InterGalax**. Aquí pódese atopar recursos, tutoriales e documentación sobre como utilizar Unity.

> - **[GitLab - Plataforma de control de versións](https://gitlab.com/)**  
  Plataforma utilizada para xestionar o código fonte do proxecto e realizar colaboracións. Asegúrate de crear unha conta para 

> - **[Asset Store de Unity](https://assetstore.unity.com/)**  
  A **Asset Store** de Unity proporciona recursos gráficos, sons e outras ferramentas que axudan a mellorar o desenvolvemento dun xogo, como os que se utilizaron para crear **InterGalax**.



