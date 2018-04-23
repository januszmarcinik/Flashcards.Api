import {Topic} from '../app/flashcards/models/topic';
export const TOPICS: Topic[] = [
  {name: 'IT', value: 1, route: 'It'},
  {name: 'English-Polish', value: 2, route: 'EnPl'}
];
export const QUILL_EDITOR_MODULES = {
  toolbar: [
    ['bold', 'italic', 'underline', 'strike'],
    ['blockquote', 'code-block'],
    [{'header': 1}, {'header': 2}],
    [{'list': 'ordered'}, {'list': 'bullet'}],
    [{'script': 'sub'}, {'script': 'super'}],
    [{'indent': '-1'}, {'indent': '+1'}],
    [{'size': ['small', false, 'large', 'huge']}],
    [{'color': []}, {'background': []}],
    [{'align': []}],
    ['clean'],
    ['link', 'image', 'video']
  ]
};
export const GUID_EMPTY: string = '00000000-0000-0000-0000-000000000000';
