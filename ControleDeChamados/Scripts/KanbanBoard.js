﻿<style>
    #board {
        display: table;
    margin: 0;
    padding: 0;
    border-spacing: 5px;
}

    .section {
        display: table-cell;
    margin: 0;
    border: 1px solid #666;
    padding: 5px;
    width: 300px;
}

        .section.droppable {
        border: 1px dashed #666;
}

        .section > h1 {
        margin: 0;
    border-bottom: 1px solid #999;
    padding: 0;
    font-size: 12pt;
    text-align: center;
}

    .card {
        display: inline-block;
    vertical-align: top;
    margin: 10px 5px;
    padding: 10px;
    width: 100px;
    height: 100px;
    color: black;
    background: #ff8;
    cursor: move;
    text-align: center;
    font-family: "Helvetica Neue", Helvetica, Arial, "Lucida Grande", sans-serif;
    box-shadow: 2px 2px 2px #eee;
}
</style>
    <body>
        <h1>Kanban Board</h1>
        @foreach (var item in Model)
    {
            <div id="board">
                <div id="todo" class="section">


                    <h1>Em Espera</h1>
                    <div id="c2" class="card">  </div>
                    <div id="c3" class="card"><em>Retire!</em></div>
                </div>
                <div id="doing" class="section">
                    <h1>Triagem</h1>
                    <div id="c1" class="card">Learn HTML5</div>
                </div>
                <div id="done" class="section">
                    <h1>Em Atendimento</h1>
                </div>

                <div id="done" class="section">
                    <h1>Concluido</h1>
                </div>

            </div>
        }
        <script>
            var cards = document.querySelectorAll('.card');
        for (var i = 0, n = cards.length; i < n; i++) {
            var card = cards[i];
            card.draggable = true;
        };
        var board = document.getElementById('board');
        var hideMe;
        board.onselectstart = function (e) {
                e.preventDefault();
            }
        board.ondragstart = function (e) {
                console.log('dragstart');
            hideMe = e.target;
            e.dataTransfer.setData('card', e.target.id);
            e.dataTransfer.effectAllowed = 'move';
        };
        board.ondragend = function (e) {
                e.target.style.visibility = 'visible';
            };
            var lastEneterd;
        board.ondragenter = function (e) {
                console.log('dragenter');
            if (hideMe) {
                hideMe.style.visibility = 'hidden';
            hideMe = null;
        }
        // Save this to check in dragleave.
        lastEntered = e.target;
        var section = closestWithClass(e.target, 'section');
        // TODO: Check that it's not the original section.
            if (section) {
                section.classList.add('droppable');
            e.preventDefault(); // Not sure if these needs to be here. Maybe for IE?
            return false;
        }
    };
        board.ondragover = function (e) {
            // TODO: Check data type.
            // TODO: Check that it's not the original section.
            if (closestWithClass(e.target, 'section')) {
                e.preventDefault();
            }
        };
        board.ondragleave = function (e) {
            // FF is raising this event on text nodes so only check elements.
            if (e.target.nodeType === 1) {
                // dragleave for outer elements can trigger after dragenter for inner elements
                // so make sure we're really leaving by checking what we just entered.
                // relatedTarget is missing in WebKit: https://bugs.webkit.org/show_bug.cgi?id=66547
                var section = closestWithClass(e.target, 'section');
                if (section && !section.contains(lastEntered)) {
                section.classList.remove('droppable');
            }
        }
        lastEntered = null; // No need to keep this around.
    };
        board.ondrop = function (e) {
            var section = closestWithClass(e.target, 'section');
            var id = e.dataTransfer.getData('card');
            if (id) {
                var card = document.getElementById(id);
            // Might be a card from another window.
                if (card) {
                    if (section !== card.parentNode) {
                section.appendChild(card);
            }
                } else {
                alert('couldn\'t find card #' + id);
            }
        }
        section.classList.remove('droppable');
        e.preventDefault();
    };
        function closestWithClass(target, className) {
            while (target) {
                if (target.nodeType === 1 &&
                    target.classList.contains(className)) {
                    return target;
        }
        target = target.parentNode;
    }
    return null;
}
    </script>
    </body>