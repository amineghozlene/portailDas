function initialisationProfile() {
}
function modifierCompte() {

    // Variables globales pour controler saisies
    var verifierEmail = /^[a-z0-9._-]+@[a-z0-9.-]{2,}[.][a-z]{2,3}$/;
    erreur = false;
    messageErreur = '';
    $('#profile .form-control').each(function () {
        if ($(this).val() != '') {
            erreur = false;
            messageErreur = '';
            $(this).removeClass('erreurSaisie');
        } else {
            erreur = true;
            $(this).addClass('erreurSaisie');
        }
    });
    if (verifierEmail.exec($('#register-email').val().trim().toLowerCase()) == null) {

        messageErreur += 'Email incorrect.<br/>';
        $('#register-email').addClass('erreurSaisie');
    }
    //if ($('#register-password').val() != $('#register-confirm').val()) {
    //    messageErreur += 'Password incorrect.<br/>';
    //    $('#register-confirm').addClass('erreurSaisie');
    //}
    if (erreur == true) {
        messageErreur += 'Champ obligatoire doit etre rempli.<br/>';
    }
    if (messageErreur == '') {
        $.ajax({
            type: "POST",
            data: {
                'register-nom': $('#register-nom').val(),
                'register-prenom': $('#register-prenom').val(),
                'register-email': $('#register-email').val(),
                'register-login': $('#register-login').val(),
                'register-societe': $('#register-societe').val(),
                'register-commerce': $('#register-commerce').val(),
                'matricule-fiscale': $('#matricule-fiscale').val(),
                'adresse': $('#adresse').val(),
                'operateur': $('#operateur').val(),
                'typeCarte': $('#typeCarte').val(),
                'codeAutorisation': $('#codeAutorisation').val()
            },
            url: "/accueil/modifierProfil",
            success: function (retourServeur) {
                $('html,body').scrollTop(0);
                
                $('body').html(retourServeur);
                $('.alert-success .alert-content p').html('Les modifications ont été faites avec succèes!');
                $('.alert-success').show();
                $('#profile .form-control').each(function () {
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