/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ClientContainerComponent } from './client-container.component';

let component: ClientContainerComponent;
let fixture: ComponentFixture<ClientContainerComponent>;

describe('ClientContainer component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ClientContainerComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ClientContainerComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
