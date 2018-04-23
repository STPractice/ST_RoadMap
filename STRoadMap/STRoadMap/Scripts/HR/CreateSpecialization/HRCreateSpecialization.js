'use strict'

var i = 0;
$(document).ready(function () {
    $(document).on('click', '.add', function () {
        var addedSkill = document.getElementById(this.id.substring(3, this.id.length));
        var elem = this.id.substring(3, this.id.length);
        var text = addedSkill.firstElementChild.textContent;
        $('#' + elem).remove();
        $('.chosen').append($('<div></div>')
            .addClass('skill')
            .attr('id', i)
            .html(`
           <p>${text}</p>
           <div class="delete" id="delete${i}">Delete</div>
        `)
        );
        i++;
    });

    $(document).on('click', '.delete', function () {        
        var deletedSkill = document.getElementById(this.id.substring(6, this.id.length));
        var text = deletedSkill.firstElementChild.textContent;
        var elem = this.id.substring(6, this.id.length);
        $('#' + elem).remove();

        $('.available').append($('<div></div>')
            .addClass('skill')
            .attr('id', i + 100)
            .html(`
           <p>${text}</p>
           <div class="add" id="add${i + 100}">Add</div>
        `)
        );
        i--;
    });

});