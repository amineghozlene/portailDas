function initialisationInscription() {
}
function inscription() {
    // Variables globales pour controler saisies
    var verifierEmail = /^[a-z0-9._-]+@[a-z0-9.-]{2,}[.][a-z]{2,3}$/;
    erreur = false;
    messageErreur = '';
    $('#inscription .form-control').each(function () {
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
    if ($('#register-password').val() != $('#register-confirm').val()) {
        messageErreur += 'Password incorrect.<br/>';
        $('#register-confirm').addClass('erreurSaisie');
    }
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
                'register-password': $('#register-password').val(),
                'register-societe': $('#register-societe').val()
            },
            url: "/accueil/inscription",
            success: function (msg) {
                $('.alert-success .alert-content p').html('L\'inscription est faite avec succèes!');
                $('.alert-success').show();

                $('#login-register').modal('hide');
                $('#inscription .form-control').each(function () {
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
function seConnecter() {

    if ($('#username').val().trim() != "" && $('#password').val().trim() != "") {
        $.ajax({
            url: '/accueil/seConnecter',
            type: 'POST',
            //async: false,
            //cache: false,
            data: {
                'identifiant': $('#username').val(),
                'motDePasse': $('#password').val()/*,
                'resterConnecter': ($('#resterConnecter[type]').is(':checked') ? 'oui' : 'non')*/
            },
            success: function (retourServeur) {
                //masquerChargement();
                if (retourServeur.indexOf('authentificationEchouee') == -1 ) {
                    $('body').html(retourServeur);
                    $('#login-register').modal('hide');
                    //initialiserLayoutWebShop();
                } else {
                    $('#password').val("");
                    $('#username').val('LOGIN_OU_MOT_DE_PASSE_INCORRECT');
                    $('#username').css('color', 'red');
                }
            }

        });
        //        }
    } else {
        $('#username').val('LOGIN_OU_MOT_DE_PASSE_INCORRECT');
        $('#username').css('color', 'red');
    }
}
function deconnexion() {

    $.ajax({
        url: '/accueil/seDeconnecter',
        async: false,
        cache: false,
        type: 'POST',
        success: function (resultat) {
            //clearTimeout(compteurRedirectionSiTimeout);
            //masquerChargement();
            $('body').html(resultat);
        }
    });
}

function afficherProfile(){

    $.ajax({
        url: '/accueil/afficherProfil',
        async: false,
        cache: false,
        type: 'POST',
        success: function (resultat) {
            //clearTimeout(compteurRedirectionSiTimeout);
            //masquerChargement();
            $('body').html(resultat);
        }
    });
}
function toggle() {
    var element = document.getElementById('register-typesociete');
    var element1 = document.getElementById('entreprise');
    var element2 = document.getElementById('universite');
    var element3 = document.getElementById('role');


            if (element==0) {
                element2.style.display = 'initial';
                element3.style.display = 'initial';
                element1.style.display = 'none';
                
            } else {
                element2.style.display = 'none';
                element3.style.display = 'none';
                element1.style.display = 'initial';
            }
        }

    

