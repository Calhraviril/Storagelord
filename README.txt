CREATE TABLE Tuotteet (
	id int primary key,
	tuotenimi varchar(10) not null,
	tuotehinta float not null,
	varastoSaldo int not null
);

Tietokannan nimi on "Varastohallinta"