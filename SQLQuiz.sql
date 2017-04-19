CREATE TABLE [quiz].[Pytania] (
  [idPytania] INT NOT NULL IDENTITY(1,1),
  [Pytania] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([idPytania]),
  INDEX [Pytania_UNIQUE] ([Pytania] ASC),
  INDEX [idPytania_UNIQUE] ([idPytania] ASC))


-- -----------------------------------------------------
-- Table [quiz].[DobreOdpowiedzi]
-- -----------------------------------------------------
CREATE TABLE [quiz].[DobreOdpowiedzi] (
  [idDobreOdpowiedzi] INT NOT NULL IDENTITY(1,1),
  [DobreOdpowiedzi] VARCHAR(45) NOT NULL,
  [Pytania_idPytania] INT NOT NULL,
  PRIMARY KEY ([idDobreOdpowiedzi], [Pytania_idPytania]),
  INDEX [DobreOdpowiedzi_UNIQUE] ([DobreOdpowiedzi] ASC),
  INDEX [idDobreOdpowiedzi_UNIQUE] ([idDobreOdpowiedzi] ASC),
  INDEX [fk_DobreOdpowiedzi_Pytania1_idx] ([Pytania_idPytania] ASC),
  CONSTRAINT [fk_DobreOdpowiedzi_Pytania1]
    FOREIGN KEY ([Pytania_idPytania])
    REFERENCES [quiz].[Pytania] ([idPytania])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)


-- -----------------------------------------------------
-- Table [quiz].[ZleOdpowiedzi]
-- -----------------------------------------------------
CREATE TABLE [quiz].[ZleOdpowiedzi] (
  [idZleOdpowiedzi] INT NOT NULL IDENTITY(1,1),
  [ZleOdpowiedzi] VARCHAR(45) NOT NULL,
  [Pytania_idPytania] INT NOT NULL,
  PRIMARY KEY ([idZleOdpowiedzi], [Pytania_idPytania]),
  INDEX [fk_Z³eOdpowiedzi_Pytania1_idx] ([Pytania_idPytania] ASC),
  INDEX [idZleOdpowiedzi_UNIQUE] ([idZleOdpowiedzi] ASC),
  CONSTRAINT [fk_Z³eOdpowiedzi_Pytania1]
    FOREIGN KEY ([Pytania_idPytania])
    REFERENCES [quiz].[Pytania] ([idPytania])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)


-- -----------------------------------------------------
-- Table [quiz].[TabelaWynikow]
-- -----------------------------------------------------
CREATE TABLE [quiz].[TabelaWynikow] (
  [idTabelaWynikow] INT NOT NULL IDENTITY(1,1),
  [Wynik] INT NOT NULL,
  [ilDobrychOdp] INT NOT NULL,
  [Nick] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([idTabelaWynikow]),
  INDEX [idTabelaWynikow_UNIQUE] ([idTabelaWynikow] ASC))


