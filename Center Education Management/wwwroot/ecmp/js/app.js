// ===== Shared App Logic: data store, auth, helpers =====
// Works regardless of whether this script is loaded from app/index.html
// or app/dashboards/*.html, and regardless of absolute/relative serving.
const APP_ROOT = new URL('..', document.currentScript.src).href;
const STORE_KEY = 'ecmp_db_v2';

const seed = () => ({
  users: [
    {id:1, role:'super_admin', email:'super@admin.com', password:'123', name:'Platform Admin'},
    {id:2, role:'center_owner', email:'owner@center.com', password:'123', name:'Ahmed Hassan', centerId:1},
    {id:3, role:'center_admin', email:'admin@center.com', password:'123', name:'Sara Mostafa', centerId:1},
    {id:4, role:'teacher', email:'teacher@center.com', password:'123', name:'Mr. Khaled', centerId:1},
    {id:5, role:'assistant', email:'assistant@center.com', password:'123', name:'Mona Ali', centerId:1},
    {id:6, role:'student', email:'student@center.com', password:'123', name:'Omar Ibrahim', centerId:1},
    {id:7, role:'parent', email:'parent@center.com', password:'123', name:'Mrs. Ibrahim', centerId:1, childId:6},
  ],
  centers: [
    {id:1, name:'Excellence Academy', email:'info@excellence.com', phone:'01000000000', address:'Nasr City', city:'Cairo', government:'Cairo', status:'active', plan:'Pro', ownerId:2, createdAt:'2025-01-15'},
    {id:2, name:'Future Stars Center', email:'info@future.com', phone:'01111111111', address:'Maadi', city:'Cairo', government:'Cairo', status:'active', plan:'Basic', createdAt:'2025-02-10'},
  ],
  centerRequests: [
    {id:1, centerName:'Bright Minds', contactPhone:'01222333444', address:'Heliopolis', city:'Cairo', state:'waiting', createdAt:'2026-04-12'},
    {id:2, centerName:'Smart Learners', contactPhone:'01555666777', address:'Alexandria', city:'Alex', state:'waiting', createdAt:'2026-05-01'},
  ],
  plans: [
    {id:1, name:'Free', priceMonthly:0, maxStudents:50, maxTeachers:3, maxGroups:5, storageGB:1},
    {id:2, name:'Basic', priceMonthly:299, maxStudents:200, maxTeachers:10, maxGroups:20, storageGB:10},
    {id:3, name:'Pro', priceMonthly:799, maxStudents:1000, maxTeachers:50, maxGroups:100, storageGB:100},
  ],
  teachers: [
    {id:4, name:'Mr. Khaled', subject:'Mathematics', email:'teacher@center.com', phone:'01099887766', centerId:1},
    {id:8, name:'Ms. Nour', subject:'Physics', email:'nour@center.com', phone:'01088776655', centerId:1},
  ],
  assistants: [
    {id:5, name:'Mona Ali', email:'assistant@center.com', phone:'01077665544', centerId:1, permissions:['upload','grade','approve']},
  ],
  groups: [
    {id:1, name:'Math - Grade 12 - A', subject:'Mathematics', stage:'Secondary 3', teacherId:4, assistantId:5, classroom:'Room 101', schedule:'Sun/Tue 4-6 PM', capacity:25, centerId:1},
    {id:2, name:'Physics - Grade 11', subject:'Physics', stage:'Secondary 2', teacherId:8, classroom:'Room 102', schedule:'Mon/Wed 5-7 PM', capacity:20, centerId:1},
  ],
  students: [
    {id:6, name:'Omar Ibrahim', email:'student@center.com', phone:'01066554433', stage:'Secondary 3', subject:'Mathematics', parentPhone:'01055443322', centerId:1, groupIds:[1]},
    {id:9, name:'Yara Mahmoud', email:'yara@stu.com', phone:'01044332211', stage:'Secondary 3', subject:'Mathematics', parentPhone:'01033221100', centerId:1, groupIds:[1]},
    {id:10, name:'Tarek Adel', email:'tarek@stu.com', phone:'01022110099', stage:'Secondary 2', subject:'Physics', parentPhone:'01011009988', centerId:1, groupIds:[2]},
  ],
  studentLeads: [
    {id:1, name:'Hana Saeed', phone:'01099001122', stage:'Secondary 1', subject:'Math', status:'new', centerId:1},
  ],
  sessions: [
    {id:1, groupId:1, date:'2026-05-12', startTime:'16:00', endTime:'18:00', status:'scheduled'},
    {id:2, groupId:1, date:'2026-05-08', startTime:'16:00', endTime:'18:00', status:'completed'},
    {id:3, groupId:2, date:'2026-05-13', startTime:'17:00', endTime:'19:00', status:'scheduled'},
  ],
  attendance: [
    {sessionId:2, studentId:6, present:true, recordedAt:'2026-05-08 16:05'},
    {sessionId:2, studentId:9, present:true, recordedAt:'2026-05-08 16:07'},
  ],
  exams: [
    {id:1, title:'Math Mid-term', groupId:1, duration:60, totalMarks:50, passingMarks:25, status:'published', questionIds:[1,2,3]},
  ],
  // Question Bank: questions live here independently of any single exam.
  // A teacher builds up a bank of questions (per subject), then an exam simply
  // references a list of question IDs from the bank (exam.questionIds).
  // This lets the same question be reused across exams, and lets the student
  // exam page pull + shuffle questions from the bank at attempt time.
  questionBank: [
    {id:1, teacherId:4, subject:'Mathematics', topic:'Algebra', type:'MCQ', text:'2 + 2 = ?', options:['3','4','5','6'], correct:1, points:5},
    {id:2, teacherId:4, subject:'Mathematics', topic:'Algebra', type:'MCQ', text:'Square root of 16?', options:['2','3','4','5'], correct:2, points:5},
    {id:3, teacherId:4, subject:'Mathematics', topic:'Geometry', type:'TrueFalse', text:'Pi equals 3.14159...', options:['True','False'], correct:0, points:5},
  ],
  examRecords: [],
  payments: [
    {id:1, studentId:6, amount:500, type:'Monthly Fee', status:'paid', date:'2026-05-01'},
    {id:2, studentId:9, amount:500, type:'Monthly Fee', status:'pending', date:'2026-05-01'},
  ],
  content: [
    {id:1, groupId:1, title:'Algebra Notes', type:'PDF', uploadedBy:4, date:'2026-05-05'},
  ],
  assignments: [
    {id:1, groupId:1, title:'Chapter 3 Exercises', dueDate:'2026-05-15', createdBy:4},
  ],
  // Student submissions for assignments: {id, assignmentId, studentId, fileName, fileSize, mime, fileData, type, submittedAt}
  submissions: [],
  notifications: [],
});

function loadServerData(){
  if(!location.search.includes('serverData=1')) return null;
  try {
    const xhr = new XMLHttpRequest();
    xhr.open('GET', '/api/dashboard/demo-data', false);
    xhr.setRequestHeader('Accept', 'application/json');
    xhr.send(null);
    if (xhr.status >= 200 && xhr.status < 300) {
      return JSON.parse(xhr.responseText);
    }
  } catch (_) {}
  return null;
}

function withDemoFallback(serverData){
  const demo = seed();
  if(!serverData || typeof serverData !== 'object') return demo;

  const merged = {...demo};
  Object.keys(demo).forEach(key=>{
    merged[key] = Array.isArray(serverData[key]) && serverData[key].length
      ? serverData[key]
      : demo[key];
  });

  // Keep demo logins useful even when the database has real users but no
  // complete dashboard relationships yet.
  const demoUsers = demo.users.filter(u=>!merged.users.some(x=>x.email===u.email));
  merged.users = [...merged.users, ...demoUsers];
  merged.users = merged.users.map(u=>{
    if(u.role === 'parent' && !u.childId) return {...u, childId: demo.users.find(x=>x.role==='parent').childId};
    if((u.role === 'center_owner' || u.role === 'center_admin' || u.role === 'teacher' || u.role === 'assistant' || u.role === 'student') && !u.centerId){
      return {...u, centerId: demo.centers[0].id};
    }
    return u;
  });

  if(!merged.centers.some(c=>c.id===1)) merged.centers = [...demo.centers, ...merged.centers];
  if(!merged.teachers.some(t=>t.id===4)) merged.teachers = [...demo.teachers, ...merged.teachers];
  if(!merged.assistants.some(a=>a.id===5)) merged.assistants = [...demo.assistants, ...merged.assistants];
  if(!merged.students.some(s=>s.id===6)) merged.students = [...demo.students, ...merged.students];
  if(!merged.groups.some(g=>g.id===1)) merged.groups = [...demo.groups, ...merged.groups];

  return merged;
}

function loadLocalData(){
  try {
    const stored = JSON.parse(localStorage.getItem(STORE_KEY));
    if(!stored || typeof stored !== 'object') return null;
    return withDemoFallback(stored);
  } catch {
    return null;
  }
}

const DB = {
  load(){
    const serverData = loadServerData();
    if(serverData) return withDemoFallback(serverData);
    return loadLocalData() || seed();
  },
  save(d){ localStorage.setItem(STORE_KEY, JSON.stringify(d)); },
  reset(){ localStorage.removeItem(STORE_KEY); localStorage.removeItem('ecmp_session'); this._d = null; },
  get(){ if(!this._d) this._d = this.load(); return this._d; },
  commit(){ this.save(this._d); },
};

const Auth = {
  login(email, password, role){
    const u = DB.get().users.find(x => x.email===email && x.password===password && (!role || x.role===role));
    if(u){ localStorage.setItem('ecmp_session', JSON.stringify(u)); return u; }
    return null;
  },
  current(){ try { return JSON.parse(localStorage.getItem('ecmp_session')); } catch { return null; } },
  logout(){ localStorage.removeItem('ecmp_session'); window.location.href=APP_ROOT+'index.html'; },
  require(role){
    const u = this.current();
    if(!u){ window.location.href=APP_ROOT+'index.html'; return null; }
    if(role && u.role!==role){ window.location.href=APP_ROOT+'index.html'; return null; }
    return u;
  }
};

const UI = {
  toast(msg, type='success'){
    let el = document.getElementById('toast');
    if(!el){
      el = document.createElement('div');
      el.id='toast'; el.className='toast';
      document.body.appendChild(el);
    }
    el.textContent = msg;
    el.className = 'toast show ' + (type==='error'?'error':'');
    clearTimeout(this._t);
    this._t = setTimeout(()=> el.className='toast', 2600);
  },
  modal(title, bodyHtml, onSave){
    const bg = document.createElement('div');
    bg.className='modal-bg show';
    bg.innerHTML = `<div class="modal"><button class="close">×</button><h3>${title}</h3><div class="mbody">${bodyHtml}</div><div style="display:flex;gap:10px;justify-content:flex-end;margin-top:16px"><button class="btn ghost" data-act="cancel">Cancel</button>${onSave?'<button class="btn" data-act="save">Save</button>':''}</div></div>`;
    document.body.appendChild(bg);
    const close = ()=> bg.remove();
    bg.querySelector('.close').onclick = close;
    bg.querySelector('[data-act="cancel"]').onclick = close;
    if(onSave) bg.querySelector('[data-act="save"]').onclick = ()=>{ if(onSave(bg)!==false) close(); };
    bg.addEventListener('click', e=>{ if(e.target===bg) close(); });
    return bg;
  },
  confirm(msg, fn){
    if(confirm(msg)) fn();
  },
};

// ===== Content Library helpers (file upload, cards, view/download) =====
const Files = {
  read(file){
    return new Promise((resolve, reject)=>{
      const r = new FileReader();
      r.onload = ()=> resolve(r.result);
      r.onerror = ()=> reject(r.error);
      r.readAsDataURL(file);
    });
  },
  size(bytes){
    if(bytes==null) return '';
    if(bytes < 1024) return bytes + ' B';
    if(bytes < 1024*1024) return (bytes/1024).toFixed(1) + ' KB';
    return (bytes/1024/1024).toFixed(1) + ' MB';
  },
  detectType(mime){
    if(!mime) return 'Other';
    if(mime === 'application/pdf') return 'PDF';
    if(mime.startsWith('video/')) return 'Video';
    if(mime.startsWith('image/')) return 'Image';
    if(mime.startsWith('audio/')) return 'Audio';
    if(mime.includes('word') || mime.includes('presentation') || mime.includes('sheet') || mime === 'text/plain') return 'Document';
    return 'Other';
  },
  icon(type){
    return ({PDF:'📕', Video:'🎬', Image:'🖼️', Audio:'🎵', Document:'📄', Link:'🔗', Other:'📦'})[type] || '📦';
  }
};

// Opens the "Upload Content" modal with a real device file picker (+ drag & drop) or a link option.
// groups: array of {id,name} the uploader can post to
// uploaderId: id to stamp on the content record
// onSaved(entry): called with the finished content object when the user hits Save
function openContentUploadModal(groups, uploaderId, onSaved){
  const gOpt = groups.map(g=>`<option value="${g.id}">${g.name}</option>`).join('') || '<option value="">No groups available</option>';
  let picked = null; // {name, size, type, dataUrl}

  const bg = UI.modal('Upload Content', `
    <div class="field"><label>Title</label><input class="input" id="ct-title" placeholder="e.g. Algebra Notes - Chapter 3"></div>
    <div class="field"><label>Description (optional)</label><textarea id="ct-desc" rows="2" placeholder="Short note for students..."></textarea></div>
    <div class="grid-2">
      <div class="field"><label>Group</label><select id="ct-group">${gOpt}</select></div>
      <div class="field"><label>Type</label><select id="ct-type">
        <option>PDF</option><option>Video</option><option>Image</option><option>Document</option><option>Audio</option><option>Link</option><option>Other</option>
      </select></div>
    </div>
    <div class="field" id="ct-linkWrap" style="display:none"><label>Link URL</label><input class="input" id="ct-link" placeholder="https://..."></div>
    <div class="field" id="ct-fileWrap">
      <label>File from your device</label>
      <div class="dropzone" id="ct-dropzone">
        <input type="file" id="ct-file" style="display:none">
        <div id="ct-dzInner">
          <span class="dz-icon">📁</span>
          <p><b>Click to browse</b> or drag &amp; drop a file here</p>
          <small>Any file type · up to ~15MB</small>
        </div>
      </div>
    </div>
  `, m=>{
    const title = m.querySelector('#ct-title').value.trim();
    const groupId = +m.querySelector('#ct-group').value;
    const type = m.querySelector('#ct-type').value;
    if(!title){ UI.toast('Please enter a title','error'); return false; }
    if(!groupId){ UI.toast('Please select a group','error'); return false; }

    const entry = {
      id: Date.now(),
      groupId, title, type,
      description: m.querySelector('#ct-desc').value.trim(),
      uploadedBy: uploaderId,
      date: new Date().toISOString().slice(0,10),
    };
    if(type === 'Link'){
      const url = m.querySelector('#ct-link').value.trim();
      if(!url){ UI.toast('Please enter a link URL','error'); return false; }
      entry.linkUrl = url;
    } else {
      if(!picked){ UI.toast('Please choose a file to upload','error'); return false; }
      entry.fileName = picked.name;
      entry.fileSize = picked.size;
      entry.mime = picked.type;
      entry.fileData = picked.dataUrl;
    }
    onSaved(entry);
  });

  const typeSel = bg.querySelector('#ct-type');
  const linkWrap = bg.querySelector('#ct-linkWrap');
  const fileWrap = bg.querySelector('#ct-fileWrap');
  const toggleMode = ()=>{
    const isLink = typeSel.value === 'Link';
    linkWrap.style.display = isLink ? 'block' : 'none';
    fileWrap.style.display = isLink ? 'none' : 'block';
  };
  typeSel.onchange = toggleMode;
  toggleMode();

  const dz = bg.querySelector('#ct-dropzone');
  const fileInput = bg.querySelector('#ct-file');
  const dzInner = bg.querySelector('#ct-dzInner');
  const titleInput = bg.querySelector('#ct-title');

  const handleFile = async (file)=>{
    if(!file) return;
    if(file.size > 15*1024*1024){ UI.toast('File is too large (max 15MB)','error'); return; }
    try{
      const dataUrl = await Files.read(file);
      picked = { name: file.name, size: file.size, type: file.type, dataUrl };
      dzInner.innerHTML = `<span class="dz-icon">${Files.icon(Files.detectType(file.type))}</span>
        <p><b>${file.name}</b></p><small>${Files.size(file.size)} · Click to change file</small>`;
      if(!titleInput.value.trim()) titleInput.value = file.name.replace(/\.[^.]+$/, '');
      const auto = Files.detectType(file.type);
      if(auto !== 'Other') typeSel.value = auto;
      toggleMode();
    }catch(e){ UI.toast('Could not read file','error'); }
  };

  dz.onclick = ()=> fileInput.click();
  fileInput.onchange = e=> handleFile(e.target.files[0]);
  dz.addEventListener('dragover', e=>{ e.preventDefault(); dz.classList.add('drag'); });
  dz.addEventListener('dragleave', ()=> dz.classList.remove('drag'));
  dz.addEventListener('drop', e=>{ e.preventDefault(); dz.classList.remove('drag'); handleFile(e.dataTransfer.files[0]); });
}

// Renders one content-library item as a card. canDelete controls whether a delete button shows.
function contentCardHTML(c, groupName, canDelete){
  const meta = [];
  if(c.fileSize != null) meta.push(Files.size(c.fileSize));
  meta.push(c.date);
  return `<div class="content-card">
    <div class="cc-icon">${Files.icon(c.type)}</div>
    <div class="cc-body">
      <h4>${c.title}</h4>
      ${c.description ? `<p class="cc-desc">${c.description}</p>` : ''}
      <div class="cc-meta">
        <span class="badge blue">${groupName || '—'}</span>
        <span>${meta.join(' · ')}</span>
      </div>
    </div>
    <div class="cc-actions">
      <button class="btn sm" onclick="openContent(${c.id})">${c.type === 'Link' ? '🔗 Open' : '👁 View'}</button>
      ${c.fileData ? `<button class="btn sm ghost" onclick="downloadContent(${c.id})" title="Download">⬇</button>` : ''}
      ${canDelete ? `<button class="btn sm danger" onclick="delCont(${c.id})">Delete</button>` : ''}
    </div>
  </div>`;
}
function contentGrid(items, groups, canDelete){
  if(!items.length) return '<p style="color:var(--muted)">No content uploaded yet.</p>';
  return `<div class="content-grid">${items.map(c=>{
    const g = groups.find(x=>x.id===c.groupId);
    return contentCardHTML(c, g?.name, typeof canDelete === 'function' ? canDelete(c) : canDelete);
  }).join('')}</div>`;
}
window.openContent = function(id){
  const d = DB.get();
  const c = d.content.find(x=>x.id===id);
  if(!c) return;
  if(c.type === 'Link' && c.linkUrl) return window.open(c.linkUrl, '_blank');
  if(c.fileData) return window.open(c.fileData, '_blank');
  UI.toast('No file attached to this item','error');
};
window.downloadContent = function(id){
  const d = DB.get();
  const c = d.content.find(x=>x.id===id);
  if(!c || !c.fileData) return;
  const a = document.createElement('a');
  a.href = c.fileData; a.download = c.fileName || c.title;
  document.body.appendChild(a); a.click(); a.remove();
};

// ===== Assignments (with optional attached file from device) =====
// groups: array of {id,name}; creatorId stamped as createdBy; onSaved(entry) receives the finished record
function openAssignmentModal(groups, creatorId, onSaved){
  const gOpt = groups.map(g=>`<option value="${g.id}">${g.name}</option>`).join('') || '<option value="">No groups available</option>';
  let picked = null; // {name, size, type, dataUrl}

  const bg = UI.modal('Create Assignment', `
    <div class="field"><label>Title</label><input class="input" id="asg-title" placeholder="e.g. Chapter 3 Exercises"></div>
    <div class="field"><label>Instructions (optional)</label><textarea id="asg-desc" rows="2" placeholder="What should students do?"></textarea></div>
    <div class="grid-2">
      <div class="field"><label>Group</label><select id="asg-group">${gOpt}</select></div>
      <div class="field"><label>Due Date</label><input class="input" id="asg-due" type="date"></div>
    </div>
    <div class="field">
      <label>Attach a file from your device (optional)</label>
      <div class="dropzone" id="asg-dropzone">
        <input type="file" id="asg-file" style="display:none">
        <div id="asg-dzInner">
          <span class="dz-icon">📁</span>
          <p><b>Click to browse</b> or drag &amp; drop a file here</p>
          <small>Worksheet, instructions, reference file... up to ~15MB</small>
        </div>
      </div>
    </div>
  `, m=>{
    const title = m.querySelector('#asg-title').value.trim();
    const groupId = +m.querySelector('#asg-group').value;
    const dueDate = m.querySelector('#asg-due').value;
    if(!title){ UI.toast('Please enter a title','error'); return false; }
    if(!groupId){ UI.toast('Please select a group','error'); return false; }
    if(!dueDate){ UI.toast('Please pick a due date','error'); return false; }

    const entry = {
      id: Date.now(), groupId, title, dueDate,
      description: m.querySelector('#asg-desc').value.trim(),
      createdBy: creatorId,
      date: new Date().toISOString().slice(0,10),
    };
    if(picked){
      entry.fileName = picked.name;
      entry.fileSize = picked.size;
      entry.mime = picked.type;
      entry.fileData = picked.dataUrl;
      entry.type = Files.detectType(picked.type);
    }
    onSaved(entry);
  });

  const dz = bg.querySelector('#asg-dropzone');
  const fileInput = bg.querySelector('#asg-file');
  const dzInner = bg.querySelector('#asg-dzInner');

  const handleFile = async (file)=>{
    if(!file) return;
    if(file.size > 15*1024*1024){ UI.toast('File is too large (max 15MB)','error'); return; }
    try{
      const dataUrl = await Files.read(file);
      picked = { name: file.name, size: file.size, type: file.type, dataUrl };
      dzInner.innerHTML = `<span class="dz-icon">${Files.icon(Files.detectType(file.type))}</span>
        <p><b>${file.name}</b></p><small>${Files.size(file.size)} · Click to change file</small>`;
    }catch(e){ UI.toast('Could not read file','error'); }
  };

  dz.onclick = ()=> fileInput.click();
  fileInput.onchange = e=> handleFile(e.target.files[0]);
  dz.addEventListener('dragover', e=>{ e.preventDefault(); dz.classList.add('drag'); });
  dz.addEventListener('dragleave', ()=> dz.classList.remove('drag'));
  dz.addEventListener('drop', e=>{ e.preventDefault(); dz.classList.remove('drag'); handleFile(e.dataTransfer.files[0]); });
}

function assignmentCardHTML(a, groupName, canDelete, submissionCount){
  const meta = [];
  if(a.fileSize != null) meta.push(Files.size(a.fileSize));
  meta.push('Due ' + (a.dueDate || '—'));
  return `<div class="content-card">
    <div class="cc-icon">${a.fileData ? Files.icon(a.type || 'Other') : '📋'}</div>
    <div class="cc-body">
      <h4>${a.title}</h4>
      ${a.description ? `<p class="cc-desc">${a.description}</p>` : ''}
      <div class="cc-meta">
        <span class="badge blue">${groupName || '—'}</span>
        <span>${meta.join(' · ')}</span>
        ${submissionCount != null ? `<span class="badge green">${submissionCount} submitted</span>` : ''}
      </div>
    </div>
    <div class="cc-actions">
      ${a.fileData ? `<button class="btn sm" onclick="openAssignment(${a.id})">👁 View</button>
      <button class="btn sm ghost" onclick="downloadAssignment(${a.id})" title="Download">⬇</button>` : `<span style="color:var(--muted);font-size:12px;flex:1">No file attached</span>`}
      ${submissionCount != null ? `<button class="btn sm" onclick="viewSubmissions(${a.id})">📥 Submissions</button>` : ''}
      ${canDelete ? `<button class="btn sm danger" onclick="delAsg(${a.id})">Delete</button>` : ''}
    </div>
  </div>`;
}
function assignmentGrid(items, groups, canDelete, submissions){
  if(!items.length) return '<p style="color:var(--muted)">No assignments yet.</p>';
  return `<div class="content-grid">${items.map(a=>{
    const g = groups.find(x=>x.id===a.groupId);
    const subCount = submissions ? submissions.filter(s=>s.assignmentId===a.id).length : null;
    return assignmentCardHTML(a, g?.name, typeof canDelete === 'function' ? canDelete(a) : canDelete, subCount);
  }).join('')}</div>`;
}
window.openAssignment = function(id){
  const d = DB.get();
  const a = d.assignments.find(x=>x.id===id);
  if(!a || !a.fileData) return UI.toast('No file attached to this assignment','error');
  window.open(a.fileData, '_blank');
};
window.downloadAssignment = function(id){
  const d = DB.get();
  const a = d.assignments.find(x=>x.id===id);
  if(!a || !a.fileData) return;
  const el = document.createElement('a');
  el.href = a.fileData; el.download = a.fileName || a.title;
  document.body.appendChild(el); el.click(); el.remove();
};

// ===== Student: submit a solved assignment file =====
// assignment: the assignment record; studentId: the submitting student's id
function openSubmitAssignmentModal(assignment, studentId, onSaved){
  let picked = null; // {name, size, type, dataUrl}
  const bg = UI.modal('Submit: ' + assignment.title, `
    <p style="color:var(--muted);font-size:13px;margin-top:-6px">Upload your solved work for this assignment. You can resubmit to replace a previous file.</p>
    <div class="field">
      <label>Your solved file</label>
      <div class="dropzone" id="sub-dropzone">
        <input type="file" id="sub-file" style="display:none">
        <div id="sub-dzInner">
          <span class="dz-icon">📁</span>
          <p><b>Click to browse</b> or drag &amp; drop your file here</p>
          <small>Photo of your work, PDF, doc... up to ~15MB</small>
        </div>
      </div>
    </div>
  `, m=>{
    if(!picked){ UI.toast('Please attach your solved file','error'); return false; }
    const entry = {
      id: Date.now(),
      assignmentId: assignment.id,
      studentId,
      fileName: picked.name,
      fileSize: picked.size,
      mime: picked.type,
      fileData: picked.dataUrl,
      type: Files.detectType(picked.type),
      submittedAt: new Date().toLocaleString(),
    };
    onSaved(entry);
  });

  const dz = bg.querySelector('#sub-dropzone');
  const fileInput = bg.querySelector('#sub-file');
  const dzInner = bg.querySelector('#sub-dzInner');

  const handleFile = async (file)=>{
    if(!file) return;
    if(file.size > 15*1024*1024){ UI.toast('File is too large (max 15MB)','error'); return; }
    try{
      const dataUrl = await Files.read(file);
      picked = { name: file.name, size: file.size, type: file.type, dataUrl };
      dzInner.innerHTML = `<span class="dz-icon">${Files.icon(Files.detectType(file.type))}</span>
        <p><b>${file.name}</b></p><small>${Files.size(file.size)} · Click to change file</small>`;
    }catch(e){ UI.toast('Could not read file','error'); }
  };

  dz.onclick = ()=> fileInput.click();
  fileInput.onchange = e=> handleFile(e.target.files[0]);
  dz.addEventListener('dragover', e=>{ e.preventDefault(); dz.classList.add('drag'); });
  dz.addEventListener('dragleave', ()=> dz.classList.remove('drag'));
  dz.addEventListener('drop', e=>{ e.preventDefault(); dz.classList.remove('drag'); handleFile(e.dataTransfer.files[0]); });
}

// Student-facing assignment card: shows the assignment (with download if a file was attached
// by the teacher) plus this student's own submission status/actions.
function studentAssignmentCardHTML(a, groupName, mySubmission){
  const meta = [];
  if(a.fileSize != null) meta.push(Files.size(a.fileSize));
  meta.push('Due ' + (a.dueDate || '—'));
  const overdue = a.dueDate && new Date(a.dueDate) < new Date(new Date().toDateString()) && !mySubmission;
  return `<div class="content-card">
    <div class="cc-icon">${a.fileData ? Files.icon(a.type || 'Other') : '📋'}</div>
    <div class="cc-body">
      <h4>${a.title}</h4>
      ${a.description ? `<p class="cc-desc">${a.description}</p>` : ''}
      <div class="cc-meta">
        <span class="badge blue">${groupName || '—'}</span>
        <span>${meta.join(' · ')}</span>
        ${mySubmission ? `<span class="badge green">✅ Submitted</span>` : overdue ? `<span class="badge" style="background:#fde2e2;color:#b42318">⏰ Overdue</span>` : `<span class="badge amber">Pending</span>`}
      </div>
      ${mySubmission ? `<p style="color:var(--muted);font-size:12px;margin-top:4px">Your file: ${mySubmission.fileName} · submitted ${mySubmission.submittedAt}</p>` : ''}
    </div>
    <div class="cc-actions">
      ${a.fileData ? `<button class="btn sm ghost" onclick="downloadAssignment(${a.id})" title="Download assignment">⬇ Assignment</button>` : ''}
      ${mySubmission ? `<button class="btn sm ghost" onclick="downloadSubmission(${mySubmission.id})" title="Download my submission">⬇ My Work</button>
      <button class="btn sm" onclick="submitAssignment(${a.id})">🔄 Resubmit</button>` : `<button class="btn sm success" onclick="submitAssignment(${a.id})">⬆ Upload Solution</button>`}
    </div>
  </div>`;
}
function studentAssignmentGrid(items, groups, submissions, studentId){
  if(!items.length) return '<p style="color:var(--muted)">No assignments yet.</p>';
  return `<div class="content-grid">${items.map(a=>{
    const g = groups.find(x=>x.id===a.groupId);
    const mySub = submissions.find(s=>s.assignmentId===a.id && s.studentId===studentId);
    return studentAssignmentCardHTML(a, g?.name, mySub);
  }).join('')}</div>`;
}
window.downloadSubmission = function(id){
  const d = DB.get();
  const s = d.submissions.find(x=>x.id===id);
  if(!s || !s.fileData) return;
  const el = document.createElement('a');
  el.href = s.fileData; el.download = s.fileName || ('submission-'+id);
  document.body.appendChild(el); el.click(); el.remove();
};

// Teacher-facing: view all student submissions for a given assignment
window.viewSubmissions = function(assignmentId){
  const d = DB.get();
  const a = d.assignments.find(x=>x.id===assignmentId);
  if(!a) return;
  const subs = d.submissions.filter(s=>s.assignmentId===assignmentId);
  const rows = subs.map(s=>{
    const st = d.students.find(x=>x.id===s.studentId);
    return `<tr><td>${st?.name||'Unknown student'}</td><td>${s.fileName}</td><td>${Files.size(s.fileSize)}</td><td>${s.submittedAt}</td>
      <td><button class="btn sm" onclick="downloadSubmission(${s.id})">⬇ Download</button></td></tr>`;
  }).join('');
  const body = subs.length
    ? `<table><thead><tr><th>Student</th><th>File</th><th>Size</th><th>Submitted</th><th></th></tr></thead><tbody>${rows}</tbody></table>`
    : '<p style="color:var(--muted)">No submissions yet.</p>';
  UI.modal('Submissions: ' + a.title, body, null);
};

// Simple SVG QR placeholder generator (visual)
function makeQR(text){
  const size = 220, cells = 25;
  const r = Math.random;
  // Use seed based on text
  let seed = 0; for(const c of text) seed = (seed*31 + c.charCodeAt(0))>>>0;
  const rnd = ()=>{ seed = (seed*9301+49297)%233280; return seed/233280; };
  let svg = `<svg width="${size}" height="${size}" viewBox="0 0 ${cells} ${cells}" xmlns="http://www.w3.org/2000/svg"><rect width="${cells}" height="${cells}" fill="#fff"/>`;
  for(let y=0;y<cells;y++){
    for(let x=0;x<cells;x++){
      if(rnd()>0.5) svg += `<rect x="${x}" y="${y}" width="1" height="1" fill="#000"/>`;
    }
  }
  // corner markers
  const corner = (cx,cy)=> `<rect x="${cx}" y="${cy}" width="7" height="7" fill="#000"/><rect x="${cx+1}" y="${cy+1}" width="5" height="5" fill="#fff"/><rect x="${cx+2}" y="${cy+2}" width="3" height="3" fill="#000"/>`;
  svg += corner(0,0)+corner(cells-7,0)+corner(0,cells-7);
  svg += '</svg>';
  return svg;
}

// Sidebar navigation helper
function setupNav(){
  document.querySelectorAll('[data-page]').forEach(a=>{
    a.onclick = e=>{
      e.preventDefault();
      const id = a.dataset.page;
      document.querySelectorAll('.page').forEach(p=>p.classList.remove('active'));
      document.getElementById('page-'+id)?.classList.add('active');
      document.querySelectorAll('.nav a').forEach(n=>n.classList.remove('active'));
      a.classList.add('active');
      const t = document.getElementById('topbar-title');
      if(t) t.textContent = a.dataset.title || a.textContent.trim();
    };
  });
  document.querySelectorAll('.logout').forEach(b=> b.onclick = ()=> Auth.logout());
  // activate first
  document.querySelector('.nav a')?.click();
}

function topbar(user){
  const initials = (user.name||'U').split(' ').map(s=>s[0]).slice(0,2).join('').toUpperCase();
  return `<div class="topbar"><h1 id="topbar-title">Dashboard</h1>
    <div class="user-chip"><span>${user.name} · <em style="color:var(--accent)">${user.role.replace('_',' ')}</em></span><div class="avatar">${initials}</div></div>
  </div>`;
}
