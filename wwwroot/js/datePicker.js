// ========================
// CUSTOM DATE PICKER
// ========================
window.datePicker = {
    init: function (inputId, availableDates, dotNetRef) {
        const input = document.getElementById(inputId);
        if (!input) return;

        // Detect unlimited mode → all dates available
        const unlimited = (availableDates === null);

        // Convert dates into fast lookup set
        const availableSet = new Set((availableDates || []).map(d => d));

        // Inject styles once
        if (!document.getElementById('datePicker-styles')) {
            const style = document.createElement('style');
            style.id = 'datePicker-styles';
            style.textContent = `
                .dp-popup { position: absolute; z-index: 9999; background:#fff; border:1px solid #ccc; padding:6px; box-shadow:0 4px 12px rgba(0,0,0,.1); }
                .dp-header { display:flex; justify-content:space-between; align-items:center; margin-bottom:6px; }
                .dp-grid { display:grid; grid-template-columns:repeat(7,28px); gap:4px; }
                .dp-cell { width:28px; height:28px; display:flex; align-items:center; justify-content:center; cursor:pointer; border-radius:4px; user-select:none; }
                .dp-cell.unavailable { background:#ffecec; color:#8a1f1f; cursor:default; opacity:0.8; }
                .dp-cell.available { background:#e6ffea; color:#045c2b; }
                .dp-cell.other-month { opacity:0.35; }
                .dp-cell:hover.available { box-shadow: inset 0 0 0 2px rgba(0,0,0,0.06); transform:translateY(-1px); }
                .dp-weekdays { display:grid; grid-template-columns:repeat(7,28px); font-size:12px; color:#666; margin-bottom:4px; }
            `;
            document.head.appendChild(style);
        }

        // Popup
        let popup = null;
        let shownMonth = null;

        function isoDate(d) {
            const yyyy = d.getFullYear();
            const mm = String(d.getMonth() + 1).padStart(2, '0');
            const dd = String(d.getDate()).padStart(2, '0');
            return `${yyyy}-${mm}-${dd}`;
        }

        function createPopup() {
            popup = document.createElement('div');
            popup.className = 'dp-popup';
            popup.tabIndex = -1;

            const header = document.createElement('div');
            header.className = 'dp-header';

            const prev = document.createElement('button');
            prev.textContent = '<';
            prev.type = 'button';
            prev.onclick = () => changeMonth(-1);

            const next = document.createElement('button');
            next.textContent = '>';
            next.type = 'button';
            next.onclick = () => changeMonth(1);

            const title = document.createElement('div');
            title.style.fontWeight = '600';

            header.appendChild(prev);
            header.appendChild(title);
            header.appendChild(next);

            const weekdays = document.createElement('div');
            weekdays.className = 'dp-weekdays';
            ['Su','Mo','Tu','We','Th','Fr','Sa'].forEach(w => {
                const wEl = document.createElement('div');
                wEl.style.textAlign = 'center';
                wEl.textContent = w;
                weekdays.appendChild(wEl);
            });

            const grid = document.createElement('div');
            grid.className = 'dp-grid';

            popup.appendChild(header);
            popup.appendChild(weekdays);
            popup.appendChild(grid);

            popup._title = title;
            popup._grid = grid;

            document.body.appendChild(popup);

            // Close when clicking outside
            setTimeout(() => {
                window.addEventListener('click', onWindowClick);
            }, 0);
        }

        function render() {
            if (!popup) createPopup();
            const rect = input.getBoundingClientRect();
            popup.style.top = (window.scrollY + rect.bottom + 6) + 'px';
            popup.style.left = (window.scrollX + rect.left) + 'px';

            const dt = shownMonth || new Date();
            const year = dt.getFullYear();
            const month = dt.getMonth();
            popup._title.textContent = dt.toLocaleString(undefined, { month: 'long', year: 'numeric' });

            const firstOfMonth = new Date(year, month, 1);

            const startDay = new Date(firstOfMonth);
            startDay.setDate(1 - firstOfMonth.getDay());

            popup._grid.innerHTML = '';

            for (let i = 0; i < 42; i++) {
                const cellDate = new Date(startDay);
                cellDate.setDate(startDay.getDate() + i);

                const cell = document.createElement('div');
                cell.className = 'dp-cell';

                if (cellDate.getMonth() !== month)
                    cell.classList.add('other-month');

                const iso = isoDate(cellDate);

                // NEW LOGIC ↓↓↓
                if (unlimited || availableSet.has(iso)) {
                    cell.classList.add('available');
                    cell.onclick = () => {
                        try { dotNetRef.invokeMethodAsync('SetTravelDate', iso); } catch {}
                        input.value = iso;
                        hide();
                    };
                } else {
                    cell.classList.add('unavailable');
                }

                cell.textContent = cellDate.getDate();
                popup._grid.appendChild(cell);
            }
        }

        function changeMonth(delta) {
            if (!shownMonth) shownMonth = new Date();
            shownMonth = new Date(shownMonth.getFullYear(), shownMonth.getMonth() + delta, 1);
            render();
        }

        function show() {
            if (!popup) createPopup();

            const currentIso = input.value;
            if (currentIso) {
                const parts = currentIso.split('-').map(x => parseInt(x, 10));
                shownMonth = new Date(parts[0], parts[1] - 1, 1);
            } else {
                shownMonth = new Date();
            }

            render();
            popup.style.display = 'block';
        }

        function hide() {
            if (!popup) return;
            popup.style.display = 'none';
            window.removeEventListener('click', onWindowClick);
        }

        function onWindowClick(e) {
            if (!popup) return;
            if (e.target === input) return;
            if (popup.contains(e.target)) return;
            hide();
        }

        input.addEventListener('focus', show);
        input.addEventListener('click', show);

        const observer = new MutationObserver(() => {
            if (!document.body.contains(input)) {
                hide();
                observer.disconnect();
            }
        });
        observer.observe(document.body, { childList: true, subtree: true });
    }
};
