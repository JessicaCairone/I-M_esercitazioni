function RenderAll(){
    $.ajax(
        {
            url: "http://localhost:5062/api/reparti",
            type: "GET",
            success: function(response) {
                let content = "";
                for(let [idx, item] of result.entries()){
                    content +=`
                    <tr>
                    <td>${item.cod}</td>
                    <td>${item.nom}</td>
                    <td>${item.fil}</td>
                    <td>
                        <button type="button" class="btn btn-danger" onclick="Delete(${item.cod})">Elimina</button>
                        <button type="button" class="btn btn-warning" onclick="openModal">Modifica</button>
                    </td>
                    </tr>
                    `;
                }
                $("#body-table_r").html(content);
            },
            error: function(errore){
                alert("Si è verificato un errore nella renderizzazione");
                console.log(errore);
            }
            
        }
    );
}

function Delete(varCod){
    $.ajax(
        {
            url: "http://localhost:5062/api/reparti" + varCod,
            type: "DELETE",
            success: function(){
                alert("Eliminazione eseguita con successo");
                RenderAll();
            },
            error: function(errore){
                alert("Si è verificato un errore nell'eliminazione");
                console.log(errore);
            }
        }
    );
}

function Insert(){

    let varCod = $("#input-codice").val();
    let varNom = $("#input-nome").val();
    let varFil = $("#input-fila").val();
    
    if(varCod.trim() == ""){
        alert("Compila il campo codice");
        $("#ins-codice").focus();
        return;
    }

    if(varNom.trim() == ""){
        alert("Compila il campo nome");
        $("#ins-nome").focus();
        return;
    }
    
    if(varFil.trim() == ""){
        alert("Compila il campo fila");
        $("#ins-fila").focus();
        return;
    }

    $.ajax(
        {
            url:"http://localhost:5062/api/reparti",
            type:"POST",
            data: JSON.stringify(
                {
                    cod: varCod,
                    nom: varNom,
                    fil: varFil 
                }
            ),
            contentType: "application-json",
            success: function(){
                alert("Inserimento avvenuto con successo");
                RenderAll();
            },
            error: function(errore){
                alert("Si è verificato un errore nell'inserimento");
                console.log(errore);
            },
            complete: function(){
                alert("Fine operazione");
            }
        }
    );
}

function openModal() {
    $('#updateModal').modal('show');
}

function Update(varCod) {

    $.ajax(
        {
            url:"http://localhost:5062/api/reparti" + varCod,
            type:"PUT",
            success: function(){
                alert("Modifiche effettuate con successo");
                RenderAll();
            },
            error: function(errore){
                alert("Si è verificato un errore durante la modifica");
                console.log(errore);
            }
        }
            );
        }
    

RenderAll();

