﻿using EjercicioVideoClub.Clases.Estados;

namespace EjercicioVideoClub.Clases;

public class Pelicula
{
    public Pelicula(string titulo, double precio, List<Existencia> existencia, IEstado estado)
    {
        if (estado is EstadoDisponible && !PuedeEstarDisponible(existencia))
        {
            throw new Exception("Error, una pelicula sin existencias no puede estar disponible");
        }
        Titulo = titulo;
        Precio = precio;
        Existencia = existencia;
        Estado = estado;
    }
    public string Titulo { get; set; }
    public double Precio { get; set; }
    public List<Existencia> Existencia { get; set; }
    public IEstado Estado { get; set; }
    public void Alquilar(FormatoExistencia formato)
    {
        Estado.Alquilar(this, formato);
    }
    private bool PuedeEstarDisponible(List<Existencia> existencia)
    {
        return existencia.Exists(existencia => existencia.TieneCopiasDisponibles());
    }
}