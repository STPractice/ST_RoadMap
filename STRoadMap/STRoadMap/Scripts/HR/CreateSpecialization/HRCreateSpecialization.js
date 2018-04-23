'use strict'

var i = 0;
$(document).ready(function () {
    var elements = document.getElementById('1');
    $(document).on('click', '.add', function () {
        var addedSkill = document.getElementById(this.id.substring(3, this.id.length));
        var elem = $('#' + this.id.substring(3, this.id.length));
        var text = addedSkill.firstElementChild.textContent;
        elem.remove();
        $('.chosen').append($('<div></div>')
            .addClass('skill')
            .attr('id', i)
            .html(`
           <p>${text}</p>
           <button class="delete" id="delete${i}">Delete</button>
           <input type="hidden" name="Skill[${i}].SkillId" value="${text}" />
        `)
        );
        i++;
    });

    $(document).on('click', '.delete', function () {
        i--;
        var deletedSkill = document.getElementById(this.id.substring(6, this.id.length));
        var text = deletedSkill.firstElementChild.textContent;
        var elem = this.id.substring(6, this.id.length);
        $('#' + elem).remove();

        $('.available').append($('<div></div>')
            .addClass('skill')
            .attr('id', elem)
            .html(`
           <p>${text}</p>
           <button class="add" id="add${elem}">Add</button>
        `)
        );

    });

});