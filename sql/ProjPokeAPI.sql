drop DATABASE if exists ProjPokeAPI;
CREATE DATABASE if not exists ProjPokeAPI
default character set utf8
default collate utf8_general_ci;

use ProjPokeAPI;

create table if not exists tbl_usuario (
    idusuario int primary key auto_increment,
    nomeusuario varchar(70) not null,
    username varchar(30) unique not null,
    senha varchar(30) not null,
    email varchar(345) unique not null
);

create table if not exists tbl_pokemon (
    idpoke int primary key,
    nomepoke varchar(70) not null,
    sprite varchar(255) not null,
    tipo1 varchar(30) not null,
    tipo2 varchar(30),
    altura int not null,
    peso int not null
);

/*falta uma pk*/
create table if not exists tbl_favorito (
    idusuario int not null,
    idpoke int not null,
    FOREIGN KEY (idusuario) REFERENCES tbl_usuario (idusuario) on delete cascade on update cascade,
    FOREIGN KEY (idpoke) REFERENCES tbl_pokemon (idpoke) on delete cascade on update cascade
);

describe tbl_favorito;

insert into tbl_usuario(nomeusuario, username, senha, email) values
	('test', 'test', 'test', 'test'),
    ('Nícolas', 'BRA pão', 'senha', 'nrf2003@gmail.com');

insert into tbl_pokemon values
    (1, 'bulbasaur', 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/1.png', 'grass', 'poison', 7, 69),
    (2, 'ivysaur', 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/2.png', 'grass', 'poison', 10, 130),
    (3, 'venusaur', 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/3.png', 'grass', 'poison', 20, 1000),
    (4, 'charmander', 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/4.png', 'fire', null, 6, 85),
    (5, 'charmeleon', 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/5.png', 'fire', null, 11, 190),
    (6, 'charizard', 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/6.png', 'fire', 'flying', 17, 905),
    (7, 'squirtle', 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/7.png', 'water', null, 5, 90),
    (8, 'wartortle', 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/8.png', 'water', null, 10, 225),
    (9, 'blastoise', 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/9.png', 'water', null, 16, 855);

insert into tbl_favorito(idusuario, idpoke) values
    (1, 1),
    (2, 1),
    (2, 4),
    (2, 7);

select * from tbl_usuario;
select * from tbl_usuario where (username = 'test' or email = 'test') and senha = 'test';
select * from tbl_pokemon;
select idpoke from tbl_favorito where idusuario = 1;