﻿function demandeService() {
    messageErreur = '';
   /*
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
    if (dates.compare($('#register-dateUtilisation').val(), Date.now) == -1 || $('#register-dateUtilisation').val() == '') {
        alert("date incorrecte");
        messageErreur += 'date incorrect.<br/>';
        $('#register-dateUtilisation').addClass('erreurSaisie');
    }
    if (erreur == true) {
        messageErreur += 'Champ obligatoire doit etre rempli.<br/>';
    }
    */
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