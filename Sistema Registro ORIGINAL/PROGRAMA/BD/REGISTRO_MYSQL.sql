SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `registro` DEFAULT CHARACTER SET latin1 ;
USE `registro` ;

-- -----------------------------------------------------
-- Table `registro`.`tipos`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `registro`.`tipos` (
  `id_Tipo` TINYINT(4) NOT NULL AUTO_INCREMENT ,
  `Tipo` VARCHAR(45) NOT NULL ,
  `Habilitado` BIT(1) NOT NULL ,
  PRIMARY KEY (`id_Tipo`) ,
  UNIQUE INDEX `Tipo_UNIQUE` (`Tipo` ASC) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `registro`.`provincias`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `registro`.`provincias` (
  `id_Provincia` TINYINT(4) NOT NULL AUTO_INCREMENT ,
  `Provincias` VARCHAR(100) NOT NULL ,
  PRIMARY KEY (`id_Provincia`) ,
  UNIQUE INDEX `Provincias_UNIQUE` (`Provincias` ASC) )
ENGINE = InnoDB
AUTO_INCREMENT = 25
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `registro`.`personas`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `registro`.`personas` (
  `Dni` INT(11) NOT NULL ,
  `Nombres` VARCHAR(100) NOT NULL ,
  `Apellidos` VARCHAR(100) NOT NULL ,
  `Direccion` VARCHAR(150) NOT NULL ,
  `Telefono` BIGINT(20) NULL DEFAULT NULL ,
  `Localidad` VARCHAR(100) NOT NULL ,
  `Provincias_id_Provincia` TINYINT(4) NOT NULL ,
  PRIMARY KEY (`Dni`) ,
  UNIQUE INDEX `Dni_UNIQUE` (`Dni` ASC) ,
  INDEX `fk_Personas_Provincias1` (`Provincias_id_Provincia` ASC) ,
  CONSTRAINT `fk_Personas_Provincias1`
    FOREIGN KEY (`Provincias_id_Provincia` )
    REFERENCES `registro`.`provincias` (`id_Provincia` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `registro`.`historico`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `registro`.`historico` (
  `id_Tramite` TINYINT(4) NOT NULL AUTO_INCREMENT ,
  `Fecha_Entrega` DATETIME NOT NULL ,
  `Codigo` VARCHAR(50) NOT NULL ,
  `Fecha` DATETIME NOT NULL ,
  `Tipos_id_Tipo` TINYINT(4) NOT NULL ,
  `Personas_Dni` INT(11) NOT NULL ,
  PRIMARY KEY (`id_Tramite`) ,
  UNIQUE INDEX `Codigo_UNIQUE` (`Codigo` ASC) ,
  INDEX `fk_Historico_Tipos1` (`Tipos_id_Tipo` ASC) ,
  INDEX `fk_Historico_Personas1` (`Personas_Dni` ASC) ,
  CONSTRAINT `fk_Historico_Tipos1`
    FOREIGN KEY (`Tipos_id_Tipo` )
    REFERENCES `registro`.`tipos` (`id_Tipo` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Historico_Personas1`
    FOREIGN KEY (`Personas_Dni` )
    REFERENCES `registro`.`personas` (`Dni` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `registro`.`pendientes`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `registro`.`pendientes` (
  `id_Tramite` TINYINT(4) NOT NULL AUTO_INCREMENT ,
  `Codigo` VARCHAR(50) NOT NULL ,
  `Nombres` VARCHAR(100) NOT NULL ,
  `Apellidos` VARCHAR(100) NOT NULL ,
  `Fecha` DATETIME NOT NULL ,
  `Tipos_id_Tipo` TINYINT(4) NOT NULL ,
  PRIMARY KEY (`id_Tramite`) ,
  UNIQUE INDEX `Codigo_UNIQUE` (`Codigo` ASC) ,
  INDEX `fk_Pendientes_Tipos` (`Tipos_id_Tipo` ASC) ,
  CONSTRAINT `fk_Pendientes_Tipos`
    FOREIGN KEY (`Tipos_id_Tipo` )
    REFERENCES `registro`.`tipos` (`id_Tipo` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `registro`.`usuarios`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `registro`.`usuarios` (
  `id_Cuenta` TINYINT(4) NOT NULL AUTO_INCREMENT ,
  `Usuario` VARCHAR(100) NOT NULL ,
  `Contraseña` VARCHAR(100) NOT NULL ,
  PRIMARY KEY (`id_Cuenta`) ,
  UNIQUE INDEX `Usuario_UNIQUE` (`Usuario` ASC) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
