CREATE TABLE t_tipo_usuario(
	id int IDENTITY NOT NULL,
	nombre_tipo varchar(100) NOT NULL,
	 PRIMARY KEY (id)
);

CREATE TABLE t_usuario(
	id int IDENTITY  NOT NULL,
	nombre_usuario varchar(100) NOT NULL,
	password varchar(100) NOT NULL,
	tipo_usuario int,
	PRIMARY KEY (id),
	CONSTRAINT FK_tipo FOREIGN KEY (tipo_usuario)
    REFERENCES t_tipo_usuario(id)
	)
