"use strict";
let dati;
$(document).ready(function ()
{
    let _div = $("#wrapper div");
    console.log(_div);
    $.ajax({
       "url": "../veicoli.json",
       "type": "GET",
       "dataType": "json",
       "async": false,
       "success": function (json)
       {
           dati=json;
           console.log(json);
       }
    });
    let _dettagli=$("#dettagli");
    _div.on("click", function ()
    {
        let text="Marca: "+dati[$(this).prop("id")]["Marca"]+"\n"+"Modello: "+dati[$(this).prop("id")]["Modello"]+"\n"+"Colore: "+dati[$(this).prop("id")]["Colore"]+"\n"+
            "Cilindrata: "+dati[$(this).prop("id")]["Cilindrata"]+"\n"+"Potenza: "+dati[$(this).prop("id")]["PotenzaKw"];
        console.log(text);
        //alert(dati[$(this).prop("id")]["Marca"] + "\n" + dati[$(this).prop("id")]["Modello"] + "\n" + dati[$(this).prop("id")]["Colore"] + "\n" + dati[$(this).prop("id")]["Cilindrata"]);
        return $("<div class='dialog'><p>"+text+"</p></div>")
            .dialog({
                resizable: true,
                modal: true,
                width:600,
                height:600
            });
    });
});