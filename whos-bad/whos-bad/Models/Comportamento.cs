//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace whos_bad.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comportamento
    {
        public int ComportamentoId { get; set; }
        public string NomeDoComportamento { get; set; }
        public int FKSentimentoId { get; set; }
        public int IntensidadeDoSentimento { get; set; }
        public int FKHumorId { get; set; }
        public int FKUserId { get; set; }
    
        public virtual Humor Humor { get; set; }
        public virtual Sentimento Sentimento { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}