using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class NoteManager : Singleton<NoteManager>
{
    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private Note notePrefab;

    private int bpm = 120;

    public ObjectPool<Note> NotePool { get; private set; }

    protected override void Awake()
    {
        NotePool = new ObjectPool<Note>(
            OnCreatePooledNote,
            OnGetNoteFromPool,
            OnReleaseNoteToPool,
            OnDestroyPooledNote,
            true,
            10,
            10
            );
        Init();
        
    }

    void Init()
    {
        float offset = 60;
        float spacing = gameCanvas.transform.position.x + offset;
        
        for(int i = 0; i < 10; ++i)
        {
            var n = NotePool.Get();
            n.transform.position = new Vector3 (spacing, gameCanvas.transform.position.y, 0f);
            spacing = n.transform.position.x + (60.0f / bpm) * 100;
        }
    }

    Note OnCreatePooledNote()
    {
        return Instantiate(notePrefab);
    }

    void OnGetNoteFromPool(Note note)
    {
        note.gameObject.SetActive(true);
        note.transform.SetParent(gameCanvas.transform, false);
        note.transform.position = Vector3.zero;
    }

    void OnReleaseNoteToPool(Note note)
    {
        note.gameObject.SetActive(false);
    }

    void OnDestroyPooledNote(Note note)
    {
        Destroy(note.gameObject);
    }
}
