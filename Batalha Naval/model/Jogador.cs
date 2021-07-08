using System;
using System.Collections.Generic;
using System.Text;

namespace Batalha_Naval.model
{
    public class Jogador
    {
        private int idJogador;
        private string nomeJogador;
        private int vitorias;
        private int derrotas;

        public Jogador(int idJogador, string nomeJogador, int vitorias, int derrotas){
            
            this.idJogador = idJogador;
            this.nomeJogador = nomeJogador;
            this.vitorias = vitorias;
            this.derrotas = derrotas;
        }

        public void setNomeJogador(string novoNome){

            this.nomeJogador = novoNome;

        }

        public string getNomeJogador(){

            return this.nomeJogador;

        }

        public void setVitorias(int novaVitoria){
        
            this.vitorias=novaVitoria; //TODO somar as vitorias, antes de chamar o set

        }

        public int getVitorias(){
            
               return this.vitorias;
        
        }

        public void setDerrotas(int novaDerrota){

            this.derrotas = novaDerrota;

        }

        public int getDerrotas(){
        
            return this.derrotas;

        }

         public override string ToString()
        {
            return "Id_Jogador:" + this.idJogador + "\nNome:" + this.nomeJogador + "\nScore de vitórias" + this.vitorias +
                    "\nScore de derrotas" + this.derrotas;
        }
    }
}
