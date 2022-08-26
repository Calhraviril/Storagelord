CREATE TABLE Tuotteet (
	id int primary key,
	tuotenimi varchar(10) not null,
	tuotehinta float not null,
	varastoSaldo int not null
);

Tietokannan nimi on "Varastohallinta"
Ja "Varastohallinta.cs" osiossa pitää kai sun erikseen vaihtaa salasanan niin että pääset sisään