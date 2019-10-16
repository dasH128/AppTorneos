using System.Collections.Generic;
using System;
using System.Linq;
using Parcial.Domain;
using Parcial.Repository.Dto;
using System.Text;

namespace Parcial.Repository.Implementation
{
    public class JugadorRepository : IJugadorRepository
    {
        private ApplicationDbContext context;

        public JugadorRepository(ApplicationDbContext context){
            this.context = context;
        }
        public bool Create(Jugador entity){
            try{
                context.Add(entity);

                Cuenta cuenta = new Cuenta{
                    JugadorId = entity.Id,
                    Correo = entity.Cuenta.Correo,
                    // Password = Encoding.ASCII.GetBytes(entity.Cuenta.Password).ToString()
                    Password = Convert.ToBase64String(Encoding.ASCII.GetBytes(entity.Cuenta.Password))
                };
                context.Cuentas.Add(cuenta);
                context.SaveChanges();
            }catch (System.Exception){
                return false;
            }
            return true;
        }


        public bool Delete(int id){
            throw new System.NotImplementedException();
        }

        public bool EmailExist(string email){
            Console.Write("Gaaa: Correo-> "+email);
            var result = true;
            try{
                bool existe = context.Cuentas.Any(t => t.Correo == email);
                result = existe;
            }catch(System.Exception){
                throw;
            }
            return result;
        }

        public IEnumerable<Jugador> FindAll(){
            var result = new List<Jugador>();
            try{
                result = context.Jugadores.ToList();
            }catch (System.Exception){
                throw;
            }
            return result;
        }

        public UsuarioDto findByEmail(string correo){
            var cuenta = new Cuenta();
            var jugador = new Jugador();
            try{
                cuenta = context.Cuentas.Single(c => c.Correo == correo);
                jugador = context.Jugadores.Single(x=> x.Id == cuenta.JugadorId);
                jugador.Cuenta = cuenta;
            }catch (System.Exception){
                return null;
            }
            var usuarioDto = new UsuarioDto();
            usuarioDto.JugadorId = jugador.Id;
            usuarioDto.Nickname = jugador.Nickname;
            usuarioDto.Correo = cuenta.Correo;
            return usuarioDto;
        }

        public Jugador FindByID(int id){
           var result = new Jugador();
           try{
               result = context.Jugadores.Single(x=> x.Id == id);
           }catch (System.Exception){
               throw;
           }
           return result;
        }

        public UsuarioDto Login(string correo, string password){
            var cuenta = new Cuenta();
            var jugador = new Jugador();
            // var myPassword = Encoding.ASCII.GetString(Convert.FromBase64String(c.Password));
            try{
                cuenta = context.Cuentas.Single(c => c.Correo == correo && Encoding.ASCII.GetString(Convert.FromBase64String(c.Password)) == password);
                jugador = context.Jugadores.Single(j => j.Id == cuenta.JugadorId);
                jugador.Cuenta = cuenta;

            }catch(System.Exception){
                return null;
            }
            var usuarioDto = new UsuarioDto();
            usuarioDto.JugadorId = jugador.Id;
            usuarioDto.Nickname = jugador.Nickname;
            usuarioDto.Correo = cuenta.Correo;

            return usuarioDto;
        }

        public bool Update(Jugador entity){
            try{
                var jugadorOrigina = context.Jugadores.Single(
                    x=>x.Id == entity.Id
                );

                jugadorOrigina.Id = entity.Id;
                jugadorOrigina.Nombre = entity.Nombre;
                jugadorOrigina.Apellido = entity.Apellido;
                jugadorOrigina.Edad = entity.Edad;
                jugadorOrigina.Nickname = entity.Nickname;

                context.Update(jugadorOrigina);
                context.SaveChanges();

            }catch (System.Exception){
                return false;
            }
            return true;
        }


    }
}