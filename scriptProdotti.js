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
                    <td>${item.codBar}</td>
                    <td>${item.nom}</td>
                    <td>${item.desc}</td>
                    <td>${item.pre}</td>
                    <td>${item.qua}</td>
                    <td>
                        <button type="button" class="btn btn-danger" onclick="Delete(${item.codBar})"></button>
                        <button type="button" class="btn btn-warning" onclick="Update(${item.codBar})"></button>
                    </td>
                    </tr>
                    `;
                }
                $("#body-table_p").html(content);
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

    let varCodBar = $("#input-codiceBarre").val();
    let varNom = $("#input-nome").val();  
    let varDesc = $("#input-descrizione").val();
    let varPre = $("#input-prezzo").val();
    let varQua = $("#input-quantita").val();
    

    $.ajax(
        {
            url:"http://localhost:5062/api/reparti",
            type:"POST",
            data: JSON.stringify(
                {
                    cod: varCodBar,
                    nom: varNom,
                    desc: varDesc,
                    pre: varPre,
                    qua: varQua

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
                alert("Operazione completata");
            }
        }
    )
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

