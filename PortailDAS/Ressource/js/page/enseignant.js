function sessionService(idService) {
        $.ajax({
         type: "POST",
         data: { 'session-service': idService },
         url: "/Enseignant/sessionService",
         success: function (retourServeur) {
             $("#register_titreService").val(retourServeur);
         }
        
     });
        $("#"+idService).attr("data-target", "#demandeService-register");
}
function demandeService() {
    alert("cc");
    messageErreur = '';
    var today = new Date();
   
    erreur = false;
   
    $('#demandeService .form-control').each(function () {
        if ($(this).val() != '') {
            erreur = false;
            messageErreur = '';
            $(this).removeClass('erreurSaisie');
        } else {
            erreur = true;
            $(this).addClass('erreurSaisie');
        }
    });
    if ($('#register-dateUtilisation').val() < today || $('#register-dateUtilisation').val() == '') {
        alert(today);
        alert("date incorrecte");
        messageErreur += 'date incorrect.<br/>';
        $('#register-dateUtilisation').addClass('erreurSaisie');
    }
    if (erreur == true) {
        messageErreur += 'Champ obligatoire doit etre rempli.<br/>';
    }
    
    if (messageErreur == '') {
        $.ajax({
            type: "POST",
            data: {
                'register-dateUtilisation': $('#register-dateUtilisation').val(),
                'register-nbrUtilisateur': $('#register-nbrUtilisateur').val(),
                'register-periode': $('#register-periode').val(),
            },
            url: "/Enseignant/demanderService",
            success: function (retourServeur) {
                $('html,body').scrollTop(0);
                $('body').html(retourServeur);
                $('.alert-success .alert-content p').html('La demande est envoyée avec succèes!');
                $('.alert-success').show();
                $('#demandeService .form-control').each(function () {
                    $(this).val('');
                });

            }
        });
    } else {
        $('.alert-error .alert-content p').html(messageErreur);
        //alerte(messageErreur);
        $('.alert-error').show();
    }
}

