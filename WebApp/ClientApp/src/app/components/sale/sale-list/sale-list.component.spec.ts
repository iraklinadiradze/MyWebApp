/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { SaleListComponent } from './sale-list.component';

let component: SaleListComponent;
let fixture: ComponentFixture<SaleListComponent>;

describe('SaleList component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ SaleListComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(SaleListComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});