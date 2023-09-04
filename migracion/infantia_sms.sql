-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: infantia
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `sms`
--

DROP TABLE IF EXISTS `sms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sms` (
  `idSms` int NOT NULL AUTO_INCREMENT,
  `idGrupo` int DEFAULT NULL,
  `mensaje` varchar(400) NOT NULL,
  `semana` int NOT NULL,
  `estado` tinyint NOT NULL,
  PRIMARY KEY (`idSms`),
  KEY `fk_Sms_Grupo1_idx` (`idGrupo`),
  CONSTRAINT `fk_Sms_Grupo1` FOREIGN KEY (`idGrupo`) REFERENCES `grupo` (`idGrupo`)
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sms`
--

LOCK TABLES `sms` WRITE;
/*!40000 ALTER TABLE `sms` DISABLE KEYS */;
INSERT INTO `sms` VALUES (1,NULL,'Te damos la bienvenida a Infantia 2. Durante este mes recibiras mensajes con consejos para mejorar el cuidado y habitos de vida saludable con tus hijos. ',0,0),(2,1,'La lactancia materna crea un vinculo afectivo entre la madre y el bebe, ademas, el bebe siente mas afecto y proteccion.',1,0),(3,1,'El pecho se debe ofrecer al bebe las veces que el quiera, el seno no tiene horario. Esto significa que el bebe toma leche cada vez que lo pide.',1,0),(4,2,'Al alimentar a los infantes es importante tener en cuenta como les presentamos la comida para tratar que comer sea una actividad divertida para ellos.',1,0),(5,2,'Evita que los infantes consuman mucho azucar.',1,0),(6,3,'Los infantes con edades de 3 a 5 empiezan a introduccir alimentos, aprender a comer solos y a utlizar cubiertos o cucharas para consumir sus alimentos. ',1,0),(7,3,'Para que tengas los nutrientes adecuados, los infantes deben comer 3 veces al dia y tomar dos meriendas.',1,0),(8,1,'Al recien nacido se le debe dar leche durante 10 a 15 minutos por cada seno, haciendo una pausa para extraerle los gases.',2,0),(9,1,'Empiece alimentacion complementaria con manzanas, peras o duraznos. Hierva por 3 minutos para hacer el pure y ofrezca la misma fruta hasta por 3 dias.',2,0),(10,2,'Comer frutas y verduras frescas en todas las comidas ayuda a protegernos de diferentes enfermedades.',2,0),(11,2,'Debemos lavar nuestras manos y cocer bien los alimentos. Recuerde que a los infantes siempre hay que lavarles las  manos  antes de comer.',2,0),(12,3,'La comida debe ser un momento agradable para los infantes, no los obliques a terminar su plato, tampoco a que coman rapido, o mientras ven la television.',2,0),(13,3,'Crea un ambiente calmado a la hora de comer y felicita a tu hijo(a) cuando coma alimentos nutritivos.',2,0),(14,1,'Los primeros dientes salen a los seis meses. Usualmente brotan los dos dientes de abajo y luego los dos de arriba.',3,0),(15,1,'Cuando los dientes del infante empiezan a salir es importante su limpieza. Por eso llevalo al dentista y limpia sus dientes al levantarse y antes de dormir.',3,0),(16,2,'Es importante lavarle los dientes al infante con muy poca cantidad de crema dental.  ',3,0),(17,2,'Hacia los 12 meses el infante no deberia alimentarse tarde en la noche. Debemos educarles  a que  hay que dormir, no comer.',3,0),(18,3,'Motiva a tu hijo(a) a ir a orinar antes de dormir. No lo castigues ni reganes por orinar la cama; es parte de su desarrollo, y dejara de hacerlo pronto.',3,0),(19,3,'La variedad es la clave. Deja que tu hijo pruebe diferentes actividades como bicicleta, baile o dibujo para mantenerlos interesados.',3,0),(20,1,'Recuerda, desde que nacen los bebes deben vacunarse para protegerlos contra las enfermedades. Recuerda que puedes vacunarlos cualquier dia y es gratis.',4,0),(21,1,'Recuerda, dormir es importante para la salud y desarrollo los bebes. Los bebes pueden dormir alrededor de 16 a 12 horas al dia',4,0),(22,2,'Durante los primeros 24 meses del infante debemos estar atentos en prevenir accidentes. Podemos organizar la casa para que sus paseos sean seguros.',4,0),(23,2,'Es importante que los infantes de 1 a 3 anos eviten estar quietos mucho tiempo. No dejemos que nuestros infantes pasen mas de 30 minutos sentados.',4,0),(24,3,'Evita que tu hijo vean el celular o la televisión antes de dormir, para que tengan una mejor calidad de sueno y se levantes descansados para el colegio. ',4,0),(25,3,'Los infantes de 3-5 anos requieren dormir de 10-13 horas en la noche. Un mal dormir afecta su el desarrollo de su cerebro.',4,0),(26,1,'El llanto de los bebes puede ser dificil de calmar cuando no se atienden sus necesidades. Intenta observar todo lo que le pueda malestar o lo haga llorar.',5,0),(27,1,'Los bebes sienten emociones como la alegria y la rabia, y las expresan con sus gestos y movimientos. Por ejemplo, si se siente alegre puede reir y moverse.',5,0),(28,2,'Cuando tu hijo se sienta angustiado ante situación estresante, debemos consolarlo y ensenarle a expresar con palabras lo que esta sintiendo.',5,0),(29,2,'Tu hijo  dependen de ti para aprender a lidiar con sus emociones. Cuando este asustado debes ensenarle con calma lo que está pasando y como reaccionar bien.',5,0),(30,3,'Es muy importante que los infantes vivan en un hogar donde haya amor y cuidados, y que en la familia pasen tiempo juntos en las actividades del hogar.',5,0),(31,3,'Guia a tu hijo(a) en el juego. Representa en tu rostro diferentes emociones y pidele que las nombre y sugiera que hacer cuando se sienta así.',5,0),(32,1,'El llanto es un lenguaje normal que los bebes usan para comunicarse. Con el llanto pueden comunicar si tienen hambre o si algo les molesta.',6,1),(33,1,'Dejar que los bebes lloren o ignorarlos puede causar en ellos angustia y estres. Recuerda buscar que puede hacer que esten llorando.',6,1),(34,2,'Los castigos deben ser inmediatos al mal comportamiento, para que tu hijo entienda que se debe al comportamiento de ese momento y no por el de hace horas.',6,1),(35,2,'Hay que evitar los castigos verbales que atacan al infante. Con ellos nunca debemos usar castigos fisicos ni agresiones verbales.',6,1),(36,3,'Establece una palabra o frase clave con tu hijo(a) para que sea una signo de alerta si se siente inseguro o incomodo con una persona o en un lugar.',6,1),(37,3,'A la hora de disciplinar a tu hijo es importante crear reglas claras en la casa. La mejor manera de educarlo es siendo un buen ejemplo. ',6,1),(38,1,'Desde el primer mes mientras lavas al bebe, lo cambias o le das el pecho, hablale. Imita sus sonidos y míralo de frente cuando lo hagas.',7,1),(39,1,'En el segundo mes de vida, el bebe comienza a balbucear y emite sonidos de ciertas vocales o de una sola silaba. Háblale con carino cuando lo escuches.',7,1),(40,2,'A partir de los 12 meses, Los infantes empiezan a emitir sonidos similares a las palabras. Háblales con afecto cuando los escuches.',7,1),(41,2,'Mientras se desarrolla el habla, algunos infantes pueden presentar tartamudeo. No te preocupes, solo alientalos con afecto para hablar despacio.',7,1),(42,3,'Comparte momentos de calidad con el bebe, con juegos y actividades juntos. Asi estimulas su aprendizaje y comunicacion.',7,1),(43,3,'Evita gritar y  pegarle a tu hijo cuando no te hace caso o tiene una rabieta. espera se calme e intenta hablar de su comportamiento amablemente y con afecto',7,1),(44,1,'Felicita y demuestrale a tu bebe lo feliz que te sientes cuando repite las silabas varias veces ma, ma, ba, ba.',8,1),(45,1,'Muestrale al bebe imagenes de animales y hazle el sonido de cada uno. Cuando le senales al perro dile que el perro hace guau.',8,1),(46,2,'A veces nos preguntamos por que los infantes no pueden estar quietos. Recuerda por su edad no pueden estar callados por mucho tiempo. Están aprendiendo de todo.',8,1),(47,2,'Si nuestro infante va al jardin antes de los tres, debemos asegurarnos que estara en un salon estimulante donde podra explorar el mundo a su propio ritmo.',8,1),(48,3,'Durante un conflicto con otros infantes, se los debe entender y guiar a todos.',8,1),(49,3,'Durante un conflicto en la casa o el jardin, haz que tu hijo se sienta seguro, y ensenale que buscas soluciones mediante el dialogo.',8,1),(50,NULL,'Gracias por participar en Infantia 2. Durante este tiempo, recibiste consejos para mejorar el cuidado de tu hijo. Esperamos te hayan ayudado.',9,1),(51,NULL,'Te invitamos a que recibas un regalo para el cuidado de tus hijos el 21 de junio a las 9.30 am en la guardería central, donde la profe Vicky. Te esperamos.',4,0),(52,NULL,'Te invitamos a que recibas un regalo para el cuidado de tus hijos el 16 de junio a las 9.30 am en el Hogar Infantil. Calle 17 No. 22 46. Te esperamos.',4,0),(53,NULL,'Te invitamos a que recibas un regalo para el cuidado de tus hijos el 22 de junio a las 9.30 am en CDI La Inmaculada. Carrera 14. vía carreto. Te esperamos.',4,0),(54,NULL,'Te invitamos a que recibas un regalo para el cuidado de tus hijos el 14 de junio a las 9.30 am en el CDI Paraiso de Amor. Villa Carolina. Te esperamos.',4,0);
/*!40000 ALTER TABLE `sms` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-25 15:58:39
